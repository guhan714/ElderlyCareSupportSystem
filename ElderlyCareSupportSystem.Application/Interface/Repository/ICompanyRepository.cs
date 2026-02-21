using ElderlyCareSupport.Domain.Entities;

namespace ElderlyCareSupportSystem.Application.Interface.Repository;

public interface ICompanyRepository
{
    Task<Company?> AddAsync(Company company);
    Task<Company?> UpdateAsync(Company company);
    Task<Company?> GetAsync(Guid companyId);
    Task<Company?> DeleteAsync(Company company);
}