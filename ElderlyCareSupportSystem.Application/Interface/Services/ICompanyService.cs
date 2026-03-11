using ElderlyCareSupportSystem.Application.Models.Reponse;
using ElderlyCareSupportSystem.Application.Models.ViewModels;

namespace ElderlyCareSupportSystem.Application.Interface.Services;

public interface ICompanyService
{
    Task<Result> CreateCompanyAsync(CompanyViewModel company);
    Task<Result> UpdateCompanyAsync(CompanyViewModel company);
    Task<Result<CompanyViewModel>> GetCompanyAsync(Guid companyId);
    Task<Result> DeleteCompanyAsync(CompanyViewModel company);
}