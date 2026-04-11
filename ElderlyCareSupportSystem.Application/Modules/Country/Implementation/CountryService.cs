using ElderlyCareSupport.Domain.Entities;
using ElderlyCareSupportSystem.Application.Models.Response;
using ElderlyCareSupportSystem.Application.Modules.Country.Contracts;

namespace ElderlyCareSupportSystem.Application.Implementation.Master;

public sealed class CountryService : ICountryService
{
    private readonly ICountryRepository _countryRepository;

    public CountryService(ICountryRepository countryRepository)
    {
        this._countryRepository = countryRepository;
    }

    public async Task<Result<IReadOnlyList<Country>>> GetCountriesAsync()
    {
        var companies = await _countryRepository.GetListAsync();
        if (companies.Count <= 0)
            return Result<IReadOnlyList<Country>>.Fail("Unable to fetch countries");
        return Result<IReadOnlyList<Country>>.Success(companies.AsReadOnly());
    }
}