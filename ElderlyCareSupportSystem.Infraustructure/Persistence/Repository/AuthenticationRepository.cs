using Dapper;
using ElderlyCareSupport.Domain.Entities;
using ElderlyCareSupport.Domain.Entities.Identity;
using ElderlyCareSupportSystem.Application.Interface.Repository;
using ElderlyCareSupportSystem.Application.Models.DTO;
using ElderlyCareSupportSystem.Infrastructure.Persistence.Data;
using Microsoft.EntityFrameworkCore;

namespace ElderlyCareSupportSystem.Infrastructure.Persistence.Repository;

public sealed class AuthenticationRepository : IAuthenticationRepository
{
    private readonly ElderlyCareSupportDbContext  _dbContext;
    private readonly DapperDbContext _dapperDbContext;

    public AuthenticationRepository(ElderlyCareSupportDbContext dbContext, DapperDbContext dapperDbContext)
    {
        _dbContext = dbContext;
        _dapperDbContext = dapperDbContext;
    }

    public async Task<UserDto?> GetAsync(string username)
    {
        using var connection = _dapperDbContext.CreateConnection();
        return await connection.QueryFirstOrDefaultAsync<UserDto>("""
                                                                  SELECT u."Username", u."Email", u."PasswordHash", r."Name" AS Role FROM "Users" AS u INNER JOIN "Roles" AS r ON u."RoleId" = r."Id" WHERE u."Username" = @username;
                                                                  """, new { username = username });
    }
}