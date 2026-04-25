using Dapper;
using ElderlyCareSupportSystem.Application.Models.DTO;
using ElderlyCareSupportSystem.Application.Modules.Authentication.Contracts;
using ElderlyCareSupportSystem.Infrastructure.Persistence.Data;

namespace ElderlyCareSupportSystem.Infrastructure.Modules.Authentication;

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
                                                                  SELECT u."Id" as UserId, u."Username", u."Email", u."PasswordHash", r."Name" AS Role FROM "Users" AS u INNER JOIN "Roles" AS r ON u."RoleId" = r."Id" WHERE u."Username" = @username;
                                                                  """, new { username = username });
    }
}