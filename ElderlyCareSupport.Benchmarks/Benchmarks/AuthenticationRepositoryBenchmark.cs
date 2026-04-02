using BenchmarkDotNet.Attributes;
using Dapper;
using dotenv.net;
using ElderlyCareSupport.Benchmarks.Setup;
using ElderlyCareSupportSystem.Application.Models.DTO;
using ElderlyCareSupportSystem.Infrastructure.Persistence.Data;
using Microsoft.EntityFrameworkCore;

namespace ElderlyCareSupport.Benchmarks.Benchmarks;

[MemoryDiagnoser]
[RankColumn]
public class AuthenticationRepositoryBenchmark : GlobalSetup
{
    private readonly string _userName = "admin";

    [GlobalSetup]
    public void Setup()
    {
        DotEnv.Load(options: new DotEnvOptions(probeForEnv: true));
        ConnectionString = Environment.GetEnvironmentVariable("ConnectionString") ?? throw new InvalidOperationException("Connection string not found");
        contextOptions = GetDbContextOptions();
    }


    [Benchmark(Baseline = true)]
    public async Task<UserDto?> GetUser_Dapper()
    {
        using var dapperDbContext = new DapperDbContext(ConnectionString);

        var connection = dapperDbContext.CreateConnection();
        var result = await connection.QueryFirstOrDefaultAsync<UserDto>(
            """SELECT u."Username", u."Email", u."PasswordHash", r."Name" AS Role FROM "Users" AS u INNER JOIN "Roles" AS r ON u."RoleId" = r."Id" WHERE u."Username" = @userName;""",
            new { userName = _userName });
        return result;
    }

    private readonly Func<ElderlyCareSupportDbContext, string, Task<UserDto?>> _getUserAsync =
        EF.CompileAsyncQuery((ElderlyCareSupportDbContext db, string userName) =>
            db.Users.AsNoTracking().Select(u => new UserDto()
            {
                UserName = u.Username,
                Email = u.Email,
                PasswordHash = u.PasswordHash,
                Role = u.Role.Name
            }).FirstOrDefault(a => a.UserName == userName));

    [Benchmark]
    public async Task<UserDto?> GetUser_EFCore()
    {
        await using var elderlyCareSupportContext = new ElderlyCareSupportDbContext(contextOptions);
        return await _getUserAsync(elderlyCareSupportContext, _userName);
    }
}