using ElderlyCareSupportSystem.Application.Modules.Authentication.Contracts;
using ElderlyCareSupportSystem.Application.Modules.Common.Contracts;
using ElderlyCareSupportSystem.Application.Modules.Company.Contracts;
using ElderlyCareSupportSystem.Application.Modules.CompanyModule.Contracts;
using ElderlyCareSupportSystem.Application.Modules.Country.Contracts;
using ElderlyCareSupportSystem.Application.Modules.Role.Contracts;
using ElderlyCareSupportSystem.Application.Modules.Security.Contracts;
using ElderlyCareSupportSystem.Application.Modules.User.Contracts;
using ElderlyCareSupportSystem.Infrastructure.Modules.Authentication;
using ElderlyCareSupportSystem.Infrastructure.Modules.Common;
using ElderlyCareSupportSystem.Infrastructure.Modules.Company;
using ElderlyCareSupportSystem.Infrastructure.Modules.Country;
using ElderlyCareSupportSystem.Infrastructure.Modules.Role;
using ElderlyCareSupportSystem.Infrastructure.Modules.Security;
using ElderlyCareSupportSystem.Infrastructure.Modules.Services.Contracts;
using ElderlyCareSupportSystem.Infrastructure.Modules.Services.Implementation;
using ElderlyCareSupportSystem.Infrastructure.Modules.User;
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

        services.AddScoped<DapperDbContext>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        
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