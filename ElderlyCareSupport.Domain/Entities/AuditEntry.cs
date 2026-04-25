using System.ComponentModel.DataAnnotations;

namespace ElderlyCareSupport.Domain.Entities;

public sealed class AuditEntry
{
    [Key]
    public Guid Id { get; set; }
    public string MetaData { get; set; }
    public DateTime StartedOn { get; set; }
    public DateTime EndedOn { get; set; }
    public bool Succeeded { get; set; }
    public string? ErrorMessage { get; set; }
}