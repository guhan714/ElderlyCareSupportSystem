namespace ElderlyCareSupportSystem.Application.Modules.Country.Contracts;

public interface ICountryRepository
{
    Task<List<ElderlyCareSupport.Domain.Entities.Country>> GetListAsync();
}