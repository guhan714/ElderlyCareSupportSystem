namespace ElderlyCareSupportSystem.Application.Modules.CompanyModule.Contracts;
using ElderlyCareSupport.Domain.Entities;

public interface ICompanyRepository
{
    Task<Company> AddAsync(Company company);
    Task<Company?> UpdateAsync(Company company);
    Task<Company?> GetAsync(Guid companyId);
    Task<Company> DeleteAsync(Company company);
}