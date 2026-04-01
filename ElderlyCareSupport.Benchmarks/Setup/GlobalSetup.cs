using ElderlyCareSupportSystem.Infrastructure.Persistence.Data;
using Microsoft.EntityFrameworkCore;

namespace ElderlyCareSupport.Benchmarks.Setup;

public abstract class GlobalSetup
{
    protected readonly string _connectionString = "Host=localhost;Port=5432;Database=ElderlyCareSupport;Username=guhan;Password=guhan712004";
    protected DbContextOptions<ElderlyCareSupportDbContext> contextOptions;


    protected DbContextOptions<ElderlyCareSupportDbContext> GetDbContextOptions()
    {
        return new DbContextOptionsBuilder<ElderlyCareSupportDbContext>()
            .UseNpgsql(_connectionString)
            .Options;
    }
}