using System.Text.Json;
using ElderlyCareSupport.Domain.Entities;
using ElderlyCareSupportSystem.Infrastructure.Persistence.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace ElderlyCareSupportSystem.Infrastructure.Modules.Common;

public sealed class EfCoreInterceptor : SaveChangesInterceptor
{
    private List<AuditEntry> AuditEntries { get; set; } = new();

    public override async ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result,
        CancellationToken cancellationToken = new CancellationToken())
    {

        if (eventData.Context is null)
        {
            return await base.SavingChangesAsync(eventData, result, cancellationToken);
        }

        var startedTime = DateTime.UtcNow;
        var auditDetails = eventData.Context.ChangeTracker
            .Entries()
            .Where(c => c.Entity is not AuditEntry 
                    && c.State is EntityState.Added or  EntityState.Modified or EntityState.Deleted)
            .Select(a => new AuditEntry
            {
                Id = Guid.CreateVersion7(),
                StartedOn = startedTime,
                MetaData = 
                    a.State switch
                    {
                        EntityState.Added => "Created",
                        
                        EntityState.Modified => JsonSerializer.Serialize(a.Properties
                            .Where(p => p.IsModified)
                            .Select(p => new
                            {
                                Property = p.Metadata.Name,
                                Old = p.OriginalValue,
                                New = p.CurrentValue
                            })),

                        EntityState.Deleted => JsonSerializer.Serialize(a.Properties.Select(p => new
                        {
                            Property = p.Metadata.Name,
                            Old = p.OriginalValue
                        })),

                        _ => "[]"
                    } ?? ""
            }).ToList();

        if (auditDetails.Count == 0)
            return await base.SavingChangesAsync(eventData, result, cancellationToken);
        
        AuditEntries.AddRange(auditDetails);
        
        return await base.SavingChangesAsync(eventData, result, cancellationToken);
    }

    public override async ValueTask<int> SavedChangesAsync(SaveChangesCompletedEventData eventData, int result,
        CancellationToken cancellationToken = new CancellationToken())
    {
        if(eventData.Context is null)
            return await base.SavedChangesAsync(eventData, result, cancellationToken);
        
        var endedTime = DateTime.UtcNow;

        foreach (var auditEntry in AuditEntries)
        {
            auditEntry.EndedOn = endedTime;
            auditEntry.Succeeded = true;
        }

        if (AuditEntries.Count > 0)
        {
            eventData.Context.Set<AuditEntry>().AddRange(AuditEntries);
            AuditEntries.Clear();
            await eventData.Context.SaveChangesAsync(cancellationToken);
        }
        
        return await base.SavedChangesAsync(eventData, result, cancellationToken);
    }
    
    public override async Task SaveChangesFailedAsync(DbContextErrorEventData eventData,
        CancellationToken cancellationToken = new CancellationToken())
    {
        if (eventData.Context is null)
            return;
        
        var endedTime = DateTime.UtcNow;

        foreach (var auditEntry in AuditEntries)
        {
            auditEntry.EndedOn = endedTime;
            auditEntry.Succeeded = false;
            auditEntry.ErrorMessage = eventData.Exception.ToString();
        }

        if (AuditEntries.Count > 0)
        {
            eventData.Context.ChangeTracker.Clear();
            eventData.Context.Set<AuditEntry>().AddRange(AuditEntries);
            AuditEntries.Clear();
            await eventData.Context.SaveChangesAsync(cancellationToken);
        }
        
        
        await base.SaveChangesFailedAsync(eventData, cancellationToken);
    }
}