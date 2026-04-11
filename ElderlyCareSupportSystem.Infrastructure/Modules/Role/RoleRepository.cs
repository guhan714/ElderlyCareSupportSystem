using Dapper;
using ElderlyCareSupportSystem.Application.Models.ViewModels;
using ElderlyCareSupportSystem.Application.Modules.Role.Contracts;
using ElderlyCareSupportSystem.Infrastructure.Persistence.Data;

namespace ElderlyCareSupportSystem.Infrastructure.Persistence.Repository;

public sealed class RoleRepository : IRoleRepository
{
    private readonly DapperDbContext _dapperDbContext;

    public RoleRepository(DapperDbContext dapperDbContext)
    {
        _dapperDbContext = dapperDbContext;
    }

    public async Task<List<RoleViewModel>> GetAllAsync()
    {
        using var connection = _dapperDbContext.CreateConnection();
        var roleCollection = await connection.QueryAsync<RoleViewModel>("""
                                                            SELECT "Id", "Code", "Name", "Description" FROM "Roles";
                                                          """);
        return roleCollection.ToList();
    }
}