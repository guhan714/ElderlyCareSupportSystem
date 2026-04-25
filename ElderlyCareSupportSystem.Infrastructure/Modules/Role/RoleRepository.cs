using Dapper;
using ElderlyCareSupportSystem.Application.Modules.Role.Contracts;
using ElderlyCareSupportSystem.Application.Modules.Role.Models;
using ElderlyCareSupportSystem.Infrastructure.Persistence.Data;
using Microsoft.EntityFrameworkCore;

namespace ElderlyCareSupportSystem.Infrastructure.Modules.Role;

public sealed class RoleRepository : IRoleRepository
{
    private readonly ElderlyCareSupportDbContext _elderlyCareSupportDbContext;
    private readonly DapperDbContext _dapperDbContext;

    public RoleRepository(DapperDbContext dapperDbContext, ElderlyCareSupportDbContext elderlyCareSupportDbContext)
    {
        _dapperDbContext = dapperDbContext;
        _elderlyCareSupportDbContext = elderlyCareSupportDbContext;
    }

    public async Task<List<RoleViewModel>> GetAllAsync()
    {
        using var connection = _dapperDbContext.CreateConnection();
        var roleCollection = await connection.QueryAsync<RoleViewModel>("""
                                                            SELECT "Id", "Code", "Name", "Description" FROM "Roles";
                                                          """);
        return roleCollection.ToList();
    }

    public async Task<RoleDto?> GetByIdAsync(Guid id)
    {
        using var connection = _dapperDbContext.CreateConnection();
        return await connection.QueryFirstOrDefaultAsync<RoleDto>($"""SELECT "Id", "Code", "Name", "Description", "IsActive" FROM "Roles" WHERE "Id" = @Id; """,  new { Id = id });
    }
    
    public Task<RoleDto?> GetDetailsByIdAsync(Guid id)
    {
        var connection = _dapperDbContext.CreateConnection();
        return connection.QueryFirstOrDefaultAsync<RoleDto>($"""
                                                             SELECT r."Id", r."Code", r."Name", r."Description", r."IsActive", u."Username", r."CreatedOn", u0."Username", r."ModifiedOn"
                                                                  FROM "Roles" AS r
                                                                  INNER JOIN "Users" AS u ON r."CreatedById" = u."Id"
                                                                  INNER JOIN "Users" AS u0 ON r."ModifiedById" = u0."Id"
                                                                  WHERE r."Id" = @id
                                                                  LIMIT 1
                                                             """, new {id = id});
    }

    public async Task<ElderlyCareSupport.Domain.Entities.Identity.Role?> AddAsync(ElderlyCareSupport.Domain.Entities.Identity.Role role)
    {
        try
        {
            await _elderlyCareSupportDbContext.Roles.AddAsync(role);
            await _elderlyCareSupportDbContext.SaveChangesAsync();
            return role;
        }
        catch (Exception ex)
        {
            return null;
        }
    }

    public async Task<ElderlyCareSupport.Domain.Entities.Identity.Role?> UpdateAsync(RoleDto roleRequest)
    {
        try
        {
            var role = await _elderlyCareSupportDbContext.Roles.FindAsync(roleRequest.Id);
            role.Name = roleRequest.Name;
            role.Description = roleRequest.Description;
            role.IsActive = roleRequest.IsActive;
            await _elderlyCareSupportDbContext.SaveChangesAsync();
            return role;
        }
        catch (Exception ex)
        {
            return null;
        }
    }

    public Task<bool> ExistsAsync(Guid roleId)
    {
        return _elderlyCareSupportDbContext.Roles.AnyAsync(a => a.Id == roleId);
    }

    public async Task<bool> RemoveAsync(Guid roleId)
    {
        var role = await  _elderlyCareSupportDbContext.Roles.FindAsync(roleId);
        _elderlyCareSupportDbContext.Roles.Remove(role);
        return await _elderlyCareSupportDbContext.SaveChangesAsync() > 0;
    }
}