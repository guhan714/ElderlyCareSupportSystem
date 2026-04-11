using ElderlyCareSupportSystem.Application.Mappers.DataTransfer;
using ElderlyCareSupportSystem.Application.Mappers.Domain.DomainMapper;
using ElderlyCareSupportSystem.Application.Models.ViewModels;
using ElderlyCareSupportSystem.Application.Modules.Company.Contracts;
using ElderlyCareSupportSystem.Application.Modules.Country.Contracts;
using ElderlyCareSupportSystem.Application.Modules.Security.Contracts;
using ElderlyCareSupportSystem.Application.Modules.User.Contracts;
using FluentValidation;
using Imposter.Abstractions;

[assembly: GenerateImposter(typeof(ICompanyRepository))]
[assembly: GenerateImposter(typeof(DomainMapper))]
[assembly: GenerateImposter(typeof(DtoMapper))]

[assembly: GenerateImposter(typeof(ICompanyService))]
[assembly: GenerateImposter(typeof(ICountryService))]
[assembly: GenerateImposter(typeof(IUserService))]

[assembly: GenerateImposter(typeof(IValidator<CompanyViewModel>))]


[assembly: GenerateImposter(typeof(IHashingService))]