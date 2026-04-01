using ElderlyCareSupportSystem.Application.Interface.Repository;
using ElderlyCareSupportSystem.Application.Interface.Security;
using ElderlyCareSupportSystem.Application.Interface.Services;
using ElderlyCareSupportSystem.Application.Mappers.DataTransfer;
using ElderlyCareSupportSystem.Application.Mappers.Domain.DomainMapper;
using ElderlyCareSupportSystem.Application.Models.ViewModels;
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