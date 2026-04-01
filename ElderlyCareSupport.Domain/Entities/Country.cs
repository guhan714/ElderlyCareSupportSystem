using System.ComponentModel.DataAnnotations;

namespace ElderlyCareSupport.Domain.Entities;

public class Country
{
    [Key]
    public Guid Id { get; set; }
    [MaxLength(30)]
    public string Code { get; set; }
    [MaxLength(70)]
    public string Name { get; set; }
}