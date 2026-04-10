using BenchmarkDotNet.Attributes;
using Dapper;
using ElderlyCareSupport.Benchmarks.Setup;
using ElderlyCareSupport.Domain.Entities;
using ElderlyCareSupportSystem.Infrastructure.Persistence.Data;
using Microsoft.EntityFrameworkCore;

namespace ElderlyCareSupport.Benchmarks.Benchmarks.Domain;

[MemoryDiagnoser]
public class CompanyRepositoryBenchmarks : GlobalSetup
{
    private Guid Id { get; } = Guid.Parse("6b847bc5-5829-4a77-a839-c8d8bb9cc33e");


    [GlobalSetup]
    public void Setup()
    {
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