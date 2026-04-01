using ElderlyCareSupportSystem.Application.Implementation.Master;
using ElderlyCareSupportSystem.Application.Implementation.Services;
using ElderlyCareSupportSystem.Application.Interface.Services;
using ElderlyCareSupportSystem.Application.Mappers.Domain.DomainMapper;
using ElderlyCareSupportSystem.Application.Validations;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using DtoMapper = ElderlyCareSupportSystem.Application.Mappers.DataTransfer.DtoMapper;

namespace ElderlyCareSupportSystem.Application.Dependency;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddValidatorsFromAssembly(typeof(CompanyValidator).Assembly);
        services.AddScoped<DomainMapper>();
        services.AddScoped<DtoMapper>();

        services.AddScoped<ICompanyService, CompanyService>();
        services.AddScoped<ICountryService, CountryService>();
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IAuthService, AuthenticationService>();
        
        services.AddScoped<IRoleService, RoleService>();
        
        return services;
    }
}