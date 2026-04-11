namespace ElderlyCareSupportSystem.Application.Modules.Company.Contracts;

public interface ICompanyRepository
{
    Task<ElderlyCareSupport.Domain.Entities.Company> AddAsync(ElderlyCareSupport.Domain.Entities.Company company);
    Task<ElderlyCareSupport.Domain.Entities.Company?> UpdateAsync(ElderlyCareSupport.Domain.Entities.Company company);
    Task<ElderlyCareSupport.Domain.Entities.Company?> GetAsync(Guid companyId);
    Task<ElderlyCareSupport.Domain.Entities.Company> DeleteAsync(ElderlyCareSupport.Domain.Entities.Company company);
}