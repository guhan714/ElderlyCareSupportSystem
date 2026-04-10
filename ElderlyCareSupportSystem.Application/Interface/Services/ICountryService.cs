using ElderlyCareSupport.Domain.Entities;
using ElderlyCareSupportSystem.Application.Models.Response;

namespace ElderlyCareSupportSystem.Application.Interface.Services;

public interface ICountryService
{
    Task<Result<IReadOnlyList<Country>>> GetCountriesAsync();
}