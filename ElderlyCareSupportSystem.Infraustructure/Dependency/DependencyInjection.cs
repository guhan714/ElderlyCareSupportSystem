using ElderlyCareSupportSystem.Application.Interface.Repository;
using ElderlyCareSupportSystem.Infraustructure.Persistence.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace ElderlyCareSupportSystem.Infraustructure.Dependency;

public static class DependencyInjection
{
    public static IServiceCollection AddElderlyCareSupportSystem(this IServiceCollection services)
    {
        services.AddScoped<ICompanyRepository, CompanyRepository>();
        return services;
    }
}