namespace ElderlyCareSupportSystem.Application.Models.ViewModels;

public sealed record LoginViewModel
{
    public string UserName { get; set; }
    public string Password { get; set; }
}