using ElderlyCareSupportSystem.Application.Implementation.Master;
using ElderlyCareSupportSystem.Application.Mappers.Domain.DomainMapper;
using ElderlyCareSupportSystem.Application.Modules.Authentication.Contracts;
using ElderlyCareSupportSystem.Application.Modules.Authentication.Implementation;
using ElderlyCareSupportSystem.Application.Modules.Company.Contracts;
using ElderlyCareSupportSystem.Application.Modules.CompanyModule.Implementation;
using ElderlyCareSupportSystem.Application.Modules.Country.Contracts;
using ElderlyCareSupportSystem.Application.Modules.Role.Contracts;
using ElderlyCareSupportSystem.Application.Modules.Role.Implementation;
using ElderlyCareSupportSystem.Application.Modules.Role.Mapper;
using ElderlyCareSupportSystem.Application.Modules.User.Contracts;
using ElderlyCareSupportSystem.Application.Modules.User.Implementation;
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
        services.AddScoped<RoleMapper>();

        services.AddScoped<ICompanyService, CompanyService>();
        services.AddScoped<ICountryService, CountryService>();
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IAuthService, AuthenticationService>();
        
        services.AddScoped<IRoleService, RoleService>();
        
        return services;
    }
}