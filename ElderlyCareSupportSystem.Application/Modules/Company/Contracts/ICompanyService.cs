using ElderlyCareSupportSystem.Application.Models.Response;
using ElderlyCareSupportSystem.Application.Models.ViewModels;

namespace ElderlyCareSupportSystem.Application.Modules.Company.Contracts;

public interface ICompanyService
{
    Task<Result> CreateCompanyAsync(CompanyViewModel company);
    Task<Result> UpdateCompanyAsync(CompanyViewModel company);
    Task<Result<CompanyViewModel>> GetCompanyAsync(Guid companyId);
    Task<Result> DeleteCompanyAsync(Guid company);
}