using ElderlyCareSupport.Domain.Entities;
using ElderlyCareSupportSystem.Application.Models.ViewModels;
using Riok.Mapperly.Abstractions;

namespace ElderlyCareSupportSystem.Application.Mappers;

[Mapper]
public partial class CompanyMapper
{
    public partial Company CompanyVmToCompany(CompanyViewModel companyViewModel);
    public partial CompanyViewModel CompanyToCompanyViewModel(Company company);
}

