using ElderlyCareSupportSystem.Application.Modules.Role.Models;
using FluentValidation;

namespace ElderlyCareSupportSystem.Application.Validations;

public sealed class RoleValidator : AbstractValidator<RoleViewModel>
{
    public RoleValidator()
    {
        RuleFor(x => x.Code).NotEmpty().WithMessage("Code is required");
        RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required");
        RuleFor(x => x.Description).NotEmpty().WithMessage("Description is required");
        RuleFor(x => x.IsActive).NotEmpty().WithMessage("IsActive is required");
    }
}