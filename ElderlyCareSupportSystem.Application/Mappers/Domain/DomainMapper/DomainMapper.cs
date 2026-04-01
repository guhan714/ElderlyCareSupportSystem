using ElderlyCareSupport.Domain.Entities;
using ElderlyCareSupport.Domain.Entities.Identity;
using ElderlyCareSupportSystem.Application.Models.DTO;
using ElderlyCareSupportSystem.Application.Models.ViewModels;
using Riok.Mapperly.Abstractions;

namespace ElderlyCareSupportSystem.Application.Mappers.Domain.DomainMapper;

[Mapper]
public partial class DomainMapper
{
    public partial Company ToCompany(CompanyViewModel companyViewModel);
    public partial User ToUser(UserDto userDto);
}