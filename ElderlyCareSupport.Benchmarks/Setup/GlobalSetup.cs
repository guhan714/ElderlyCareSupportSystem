using ElderlyCareSupportSystem.Infrastructure.Persistence.Data;
using Microsoft.EntityFrameworkCore;

namespace ElderlyCareSupport.Benchmarks.Setup;

public abstract class GlobalSetup
{
    protected string ConnectionString { get; set; }

    protected DbContextOptions<ElderlyCareSupportDbContext> contextOptions;


    protected DbContextOptions<ElderlyCareSupportDbContext> GetDbContextOptions()
    {
        return new DbContextOptionsBuilder<ElderlyCareSupportDbContext>()
            .UseNpgsql(ConnectionString)
            .Options;
    }
}