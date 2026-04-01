using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ElderlyCareSupport.Domain.Entities;

public  class User
{
    [Key]
    public Guid Id { get; set; }
    [MaxLength(50)]
    public string Username { get; set; }
    [MaxLength(100)]
    public string Email { get; set; }
    public string PasswordHash { get; set; }
    
    public Guid? CompanyId { get; set; }
    [ForeignKey(nameof(CompanyId))]
    public Company Company { get; set; }
    
    public Guid CreatedUserId { get; set; }
    public DateTime CreatedOn { get; set; }
    public Guid ModifiedUserId { get; set; }
    public DateTime ModifiedOn { get; set; }
}