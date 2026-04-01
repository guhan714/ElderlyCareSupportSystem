using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ElderlyCareSupport.Domain.Entities.Identity;

public sealed class Role
{
    public Guid Id { get; set; }
    [MaxLength(30)]
    public string Code { get; set; }
    [MaxLength(50)]
    public string Name { get; set; }
    [MaxLength(150)]
    public string Description { get; set; }
    
    public DateTime CreatedOn { get; set; }
    public Guid CreatedById { get; set; }
    [ForeignKey(nameof(CreatedById))]
    public User CreatedBy { get; set; }

    public DateTime ModifiedOn { get; set; }
    [ForeignKey(nameof(ModifiedById))]
    public Guid ModifiedById { get; set; }
    public User ModifiedBy { get; set; }
}