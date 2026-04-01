using ElderlyCareSupport.Domain.Entities;
using ElderlyCareSupportSystem.Application.Models.ViewModels;
using Riok.Mapperly.Abstractions;

namespace ElderlyCareSupportSystem.Application.Mappers.DataTransfer;

[Mapper]
public partial class DtoMapper
{
    public partial CompanyViewModel ToCompany(Company company);
}

