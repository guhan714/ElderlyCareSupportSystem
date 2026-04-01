namespace ElderlyCareSupportSystem.Application.Models.ViewModels;

public class CompanyViewModel
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string AddressLine1 { get; set; }
    public string AddressLine2 { get; set; }
    public string AddressLine3 { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public Guid CountryId { get; set; }
    public string ZipCode { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }
    public string Website { get; set; }
    public string RegistrationNumber { get; set; }
    public string UserName { get; set; }
    public string Password { get; set; }
}