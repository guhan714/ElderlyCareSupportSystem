using System.Data;
using BenchmarkDotNet.Attributes;
using Dapper;
using ElderlyCareSupport.Domain.Entities;
using ElderlyCareSupportSystem.Infrastructure.Persistence.Data;
using Npgsql;

namespace ElderlyCareSupport.Benchmarks.Benchmarks;

[MemoryDiagnoser]
public class DapperBenchmarks
{
    private IDbConnection _connection;

    [IterationSetup]
    public void GlobalSetup()
    {
        _connection =
            new NpgsqlConnection("Host=localhost;Port=5432;Database=ElderlyCareSupport;Username=guhan;Password=guhan712004");
    }
    
    [IterationCleanup]
    public void IterationCleanup()
    {
        _connection.Dispose();
    }
    
    [Benchmark(Description =  "Dapper")]
    public async Task<List<Country>> GetCountries()
    {
        var countries = await _connection.QueryAsync<Country>("""SELECT * FROM "Countries";""");
        return countries.ToList();
    }
}