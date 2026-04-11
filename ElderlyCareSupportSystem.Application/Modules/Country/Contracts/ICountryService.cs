using ElderlyCareSupportSystem.Application.Models.Response;

namespace ElderlyCareSupportSystem.Application.Modules.Country.Contracts;

public interface ICountryService
{
    Task<Result<IReadOnlyList<ElderlyCareSupport.Domain.Entities.Country>>> GetCountriesAsync();
}