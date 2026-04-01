using BenchmarkDotNet.Attributes;
using ElderlyCareSupport.Domain.Entities;
using ElderlyCareSupportSystem.Infrastructure.Persistence.Data;
using Microsoft.EntityFrameworkCore;

namespace ElderlyCareSupport.Benchmarks.Benchmarks;

[MemoryDiagnoser]
public class EFCoreBenchmarks
{
    private readonly string connectionString =
        "Host=localhost;Port=5432;Database=Learnings;Username=postgres;Password=guhan712004";

    private ElderlyCareSupportDbContext _dbContext;
    
    [GlobalSetup]
    public void GlobalSetup()
    {
        var options = new DbContextOptionsBuilder<ElderlyCareSupportDbContext>()
            .UseNpgsql(connectionString)
            .Options;
         _dbContext = new ElderlyCareSupportDbContext(options);
    }
    
    [Benchmark]
    public async Task<List<Country>> GetCountries()
    {
        
        var countries = await _dbContext.Countries.AsNoTracking().ToListAsync();
        return countries;
    }
}