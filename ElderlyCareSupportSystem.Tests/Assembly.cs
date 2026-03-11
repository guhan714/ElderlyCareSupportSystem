using ElderlyCareSupportSystem.Application.Interface.Repository;
using ElderlyCareSupportSystem.Application.Mappers;
using Imposter.Abstractions;

[assembly: GenerateImposter(typeof(ICompanyRepository))]
[assembly: GenerateImposter(typeof(CompanyMapper))]