using ElderlyCareSupportSystem.Application.Models.ViewModels;
using FluentValidation;

namespace ElderlyCareSupportSystem.Application.Validations;

public class CompanyValidator : AbstractValidator<CompanyViewModel>
{
    public CompanyValidator()
    {
        RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required");
        RuleFor(x => x.Address1).NotEmpty().WithMessage("Address1 is required");
        RuleFor(x => x.AddressLine2).NotEmpty().WithMessage("AddressLine2 is required");
        RuleFor(x => x.City).NotEmpty().WithMessage("City is required");
        RuleFor(x => x.State).NotEmpty().WithMessage("State is required");
        RuleFor(x => x.ZipCode).NotEmpty().WithMessage("ZipCode is required");
        RuleFor(x => x.Email).NotEmpty().WithMessage("Email is required").EmailAddress();
        RuleFor(x => x.PhoneNumber).NotEmpty().WithMessage("PhoneNumber is required");
        RuleFor(x => x.RegistrationNumber).NotEmpty().WithMessage("RegistrationNumber is required");
    }
}