using Dapper;
using ElderlyCareSupport.Domain.Entities.Identity;
using ElderlyCareSupportSystem.Application.Models.ViewModels;
using ElderlyCareSupportSystem.Application.Modules.User.Contracts;
using ElderlyCareSupportSystem.Infrastructure.Persistence.Data;

namespace ElderlyCareSupportSystem.Infrastructure.Persistence.Repository;

public sealed class UserRepository : IUserRepository
{
    private readonly ElderlyCareSupportDbContext _elderlyCareSupportDbContext;
    private readonly DapperDbContext _dapperDbContext;
    
    public UserRepository(ElderlyCareSupportDbContext elderlyCareSupportDbContext, DapperDbContext dapperDbContext)
    {
        _elderlyCareSupportDbContext = elderlyCareSupportDbContext;
        _dapperDbContext = dapperDbContext;
    }

    public async Task<User?> AddAsync(User user)
    {
        await _elderlyCareSupportDbContext.Users.AddAsync(user);
        await _elderlyCareSupportDbContext.SaveChangesAsync();
        return user;
    }

    public async Task<User?> UpdateAsync(User user)
    {
        _elderlyCareSupportDbContext.Update(user);
        await _elderlyCareSupportDbContext.SaveChangesAsync();
        return user;
    }

    public async Task<User?> DeleteAsync(Guid userId)
    {
        var user = await _elderlyCareSupportDbContext.Users.FindAsync(userId);
        _elderlyCareSupportDbContext.Users.Remove(user!);
        await _elderlyCareSupportDbContext.SaveChangesAsync();
        return user;
    }

    public async Task<User?> FindAsync(Guid userId)
    {
        using var connection = _dapperDbContext.CreateConnection();
        return await connection.QueryFirstOrDefaultAsync<User>("""
                                                         SELECT * FROM "Users" WHERE ID = @Id;
                                                         """, new { Id = userId });
    }

    public async Task<UserViewModel?> FindDetailsAsync(Guid userId)
    {
        using var connection = _dapperDbContext.CreateConnection();
        var user = await connection.QueryFirstOrDefaultAsync<UserViewModel>("""
            SELECT "u.Username", "u.Email", "r.Name" FROM "Users" AS u INNER JOIN "Roles" AS r ON "u.RoleId" = "r.Id" WHERE Id = @Id;
            """,  new { Id = userId });
        return user;
    }

    public async ValueTask<bool> ExistsAsync(Guid userId)
    {
        using var connection = _dapperDbContext.CreateConnection();
        return await connection.ExecuteScalarAsync<int>("""
                                           SELECT COUNT(1) FROM "Users" WHERE Id = @Id;
                                           """, new { Id = userId }) != 0; 
    }
}