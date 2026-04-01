using ElderlyCareSupport.Domain.Entities;

namespace ElderlyCareSupportSystem.Application.Interface.Repository;

public interface ICountryRepository
{
    Task<List<Country>> GetListAsync();
}