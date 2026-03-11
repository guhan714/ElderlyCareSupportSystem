using ElderlyCareSupportSystem.Application.Interface.Repository;
using ElderlyCareSupportSystem.Infrastructure.Persistence.Repository;
using ElderlyCareSupportSystem.Infrastructure.Persistence.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ElderlyCareSupportSystem.Infrastructure.Dependency;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ElderlyCareSupportDbContext>(options =>
        {
            options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"));
        });

        services.AddScoped<ICompanyRepository, CompanyRepository>();
        
        return services;
    }
}