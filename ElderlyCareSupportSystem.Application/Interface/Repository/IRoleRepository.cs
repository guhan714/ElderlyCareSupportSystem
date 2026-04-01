using ElderlyCareSupportSystem.Application.Models.ViewModels;

namespace ElderlyCareSupportSystem.Application.Interface.Repository;

public interface IRoleRepository
{
    Task<List<RoleViewModel>> GetAllAsync();
}