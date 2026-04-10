using ElderlyCareSupportSystem.Application.Interface.Repository;
using ElderlyCareSupportSystem.Application.Interface.Security;
using ElderlyCareSupportSystem.Infrastructure.Externals;
using ElderlyCareSupportSystem.Infrastructure.Persistence.Repository;
using ElderlyCareSupportSystem.Infrastructure.Persistence.Data;
using ElderlyCareSupportSystem.Infrastructure.Security.Implementation;
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

        services.AddScoped<DapperDbContext>();
        
        services.AddScoped<ICompanyRepository, CompanyRepository>();
        services.AddScoped<ICountryRepository, CountryRepository>();
        services.AddScoped<IUserRepository, UserRepository>();
        
        services.AddScoped<IAuthenticationRepository, AuthenticationRepository>();
        
        services.AddScoped<IRoleRepository, RoleRepository>();
        
        services.AddScoped<IHashingService, BCryptHashingService>();

        services.AddScoped<IEmailService, MailKitEmailService>();
        
        return services;
    }
}