using ElderlyCareSupportSystem.Application.Modules.Role.Models;
using Riok.Mapperly.Abstractions;

namespace ElderlyCareSupportSystem.Application.Modules.Role.Mapper;

[Mapper]
public partial class RoleMapper
{
    public partial RoleDto ToDto(RoleViewModel roleViewModel);
    public partial ElderlyCareSupport.Domain.Entities.Identity.Role ToUser(RoleDto role);
    public partial RoleViewModel ToViewModel(RoleDto dto);
}