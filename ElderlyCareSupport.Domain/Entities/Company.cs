using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ElderlyCareSupport.Domain.Entities;

public class Company
{
    [Key]
    public Guid Id { get; set; }
    [MaxLength(200)]
    public string Name { get; set; }
    [MaxLength(200)]
    public string AddressLine1 { get; set; }
    [MaxLength(200)]
    public string AddressLine2 { get; set; }
    [MaxLength(200)]
    public string AddressLine3 { get; set; }
    [MaxLength(200)]
    public string City { get; set; }
    [MaxLength(200)]
    public string State { get; set; }
    [MaxLength(200)]
    public string Country { get; set; }
    [MaxLength(200)]
    public string ZipCode { get; set; }
    [MaxLength(200)]
    public string PhoneNumber { get; set; }
    [MaxLength(200)]
    public string Email { get; set; }
    [MaxLength(200)]
    public string Website { get; set; }
    [MaxLength(200)]
    public string RegistrationNumber { get; set; }
    
    public Guid CreatedById { get; set; }
    [ForeignKey(nameof(CreatedById))]
    public ApplicationUser CreatedBy { get; set; }
    public DateTime CreatedOn { get; set; }
    public Guid UpdatedById { get; set; }
    [ForeignKey(nameof(UpdatedById))]
    public ApplicationUser UpdatedBy { get; set; }
    public DateTime UpdatedOn { get; set; }
}