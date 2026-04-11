namespace ElderlyCareSupportSystem.Application.Models.ViewModels;

public sealed record UserViewModel
{
    public string UserName { get; set; }
    public string Email { get; set; }
    public string Role {get; set; }
}