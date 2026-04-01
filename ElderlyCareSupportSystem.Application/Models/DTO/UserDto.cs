namespace ElderlyCareSupportSystem.Application.Models.DTO;

public class UserDto
{
    public Guid UserId { get; set; }
    public string UserName { get; set; }
    public string PasswordHash { get; set; }
    public string Email { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Role { get; set; }
    public string CompanyName { get; set; }
    public Guid CreatedByUserId { get; set; }
    public Guid ModifiedByUserId { get; set; }
}