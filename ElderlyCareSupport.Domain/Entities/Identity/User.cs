using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ElderlyCareSupport.Domain.Entities.Identity;

public  class User
{
    [Key]
    public Guid Id { get; set; }
    [MaxLength(50)]
    public string Username { get; set; }
    [MaxLength(100)]
    public string Email { get; set; }
    public string PasswordHash { get; set; }
    
    public Guid? RoleId { get; set; }
    [ForeignKey(nameof(RoleId))]
    public Role Role { get; set; }
    
    public Guid CreatedUserId { get; set; }
    public DateTime CreatedOn { get; set; }
    public Guid ModifiedUserId { get; set; }
    public DateTime ModifiedOn { get; set; }
}