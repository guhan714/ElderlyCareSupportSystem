using ElderlyCareSupportSystem.Application.Implementation.Services;
using ElderlyCareSupportSystem.Application.Interface.Services;
using ElderlyCareSupportSystem.Application.Mappers;
using ElderlyCareSupportSystem.Application.Validations;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace ElderlyCareSupportSystem.Application.Dependency;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddValidatorsFromAssembly(typeof(CompanyValidator).Assembly);
        services.AddScoped<CompanyMapper>();

        services.AddScoped<ICompanyService, CompanyService>();
        
        return services;
    }
}