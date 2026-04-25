using BenchmarkDotNet.Attributes;
using Dapper;
using ElderlyCareSupport.Benchmarks.Setup;
using ElderlyCareSupportSystem.Application.Modules.Role.Models;
using ElderlyCareSupportSystem.Infrastructure.Persistence.Data;
using Microsoft.EntityFrameworkCore;

namespace ElderlyCareSupport.Benchmarks.Benchmarks.Domain;

[MemoryDiagnoser]
public class RoleBenchmarks : GlobalSetup
{
    private Guid RoleId { get; init; } = Guid.Parse("910e2eca-4fd5-465d-b2c5-a5ba8543bd14");

    [GlobalSetup]
    public void Setup()
    {
        contextOptions = GetDbContextOptions();
    }

    [Benchmark]
    public async Task<RoleDto?> GetAsync_EFCore()
    {
        await using var db = new ElderlyCareSupportDbContext(contextOptions);
        return await db.Roles.AsNoTracking()
            .Where(r => r.Id == RoleId)
            .Select(r => new RoleDto()
            {
                Id = r.Id,
                Code = r.Code,
                Name = r.Name,
                Description = r.Description,
                IsActive = r.IsActive,
                CreatedBy = r.CreatedBy != null ? r.CreatedBy.Username : "",
                ModifiedBy = r.ModifiedBy != null ? r.ModifiedBy.Username : "",
                CreatedOn = r.CreatedOn.ToString("dd/MM/yyyy HH:mm:ss"),
                ModifiedOn = r.ModifiedOn.ToString("dd/MM/yyyy HH:mm:ss")
            }).FirstOrDefaultAsync();
    }

    [Benchmark(Baseline = true)]
    public async Task<RoleDto?> GetAsync_Dapper()
    {
        var connection = new DapperDbContext(ConnectionString);
        var db = connection.CreateConnection();
        return await db.QueryFirstOrDefaultAsync<RoleDto>($"""
                                                           SELECT r."Id", r."Code", r."Name", r."Description", r."IsActive", u."Username", r."CreatedOn", u0."Username", r."ModifiedOn"
                                                                FROM "Roles" AS r
                                                                INNER JOIN "Users" AS u ON r."CreatedById" = u."Id"
                                                                INNER JOIN "Users" AS u0 ON r."ModifiedById" = u0."Id"
                                                                WHERE r."Id" = @id
                                                                LIMIT 1
                                                           """, new { id = RoleId });
    }
}