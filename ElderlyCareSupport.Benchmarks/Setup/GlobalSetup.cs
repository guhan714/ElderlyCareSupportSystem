using dotenv.net;
using ElderlyCareSupportSystem.Infrastructure.Persistence.Data;
using Microsoft.EntityFrameworkCore;

namespace ElderlyCareSupport.Benchmarks.Setup;

public abstract class GlobalSetup
{
    protected string ConnectionString {
        get
        {
            DotEnv.Load(options: new DotEnvOptions(probeForEnv: true));
            return Environment.GetEnvironmentVariable("ConnectionString") ??
                throw new InvalidOperationException("Connection string not found");
        }
    }

    protected DbContextOptions<ElderlyCareSupportDbContext> contextOptions;


    protected DbContextOptions<ElderlyCareSupportDbContext> GetDbContextOptions()
    {
        return new DbContextOptionsBuilder<ElderlyCareSupportDbContext>()
            .UseNpgsql(ConnectionString)
            .Options;
    }
}