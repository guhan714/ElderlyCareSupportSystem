using ElderlyCareSupportSystem.Application.Models.ViewModels;
using FluentValidation;

namespace ElderlyCareSupportSystem.Application.Validations;

public class LoginValidator : AbstractValidator<LoginViewModel>
{
    public LoginValidator()
    {
        RuleFor(a => a.UserName).NotEmpty().WithMessage("Username is required");
        RuleFor(a => a.Password).NotEmpty().WithMessage("Password is required").MinimumLength(6).WithMessage("Password is minimum 6 characters");
    }
}