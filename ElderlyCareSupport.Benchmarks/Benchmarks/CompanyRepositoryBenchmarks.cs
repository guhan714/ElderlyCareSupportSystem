using BenchmarkDotNet.Attributes;
using Dapper;
using dotenv.net;
using ElderlyCareSupport.Benchmarks.Setup;
using ElderlyCareSupport.Domain.Entities;
using ElderlyCareSupportSystem.Infrastructure.Persistence.Data;
using Microsoft.EntityFrameworkCore;

namespace ElderlyCareSupport.Benchmarks.Benchmarks;

public class CompanyRepositoryBenchmarks : GlobalSetup
{
    private Guid Id { get; init; } = Guid.Parse("6b847bc5-5829-4a77-a839-c8d8bb9cc33e");


    [GlobalSetup]
    public void Setup()
    {
        DotEnv.Load(options: new DotEnvOptions(probeForEnv: true));
        ConnectionString = Environment.GetEnvironmentVariable("ConnectionString") ??
                           throw new InvalidOperationException("Connection string not found");
        contextOptions = GetDbContextOptions();
    }

    [Benchmark(Baseline = true)]
    public async Task<Company?> GetAsync_Dapper()
    {
        var connection = new DapperDbContext(ConnectionString);
        var db = connection.CreateConnection();
        return await db.QueryFirstOrDefaultAsync<Company>("""SELECT * FROM "Companies" WHERE "Id" = @Id;""",
            new { Id = Id });
    }

    private readonly Func<ElderlyCareSupportDbContext, Guid, Task<Company?>> _companyGetAsync =
        EF.CompileAsyncQuery((ElderlyCareSupportDbContext db, Guid id) =>
            db.Companies.AsNoTracking().FirstOrDefault(a => a.Id == id));

    [Benchmark]
    public async Task<Company?> GetAsync_EFCore()
    {
        await using var db = new ElderlyCareSupportDbContext(contextOptions);
        return await _companyGetAsync(db, Id);
    }
}