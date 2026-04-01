using ElderlyCareSupport.Domain.Entities;
using ElderlyCareSupportSystem.Application.Models.Reponse;

namespace ElderlyCareSupportSystem.Application.Interface.Services;

public interface ICountryService
{
    Task<Result<IReadOnlyList<Country>>> GetCountriesAsync();
}