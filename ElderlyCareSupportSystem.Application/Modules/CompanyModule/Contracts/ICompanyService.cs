using ElderlyCareSupportSystem.Application.Models.Response;
using ElderlyCareSupportSystem.Application.Models.ViewModels;

namespace ElderlyCareSupportSystem.Application.Modules.Company.Contracts;

public interface ICompanyService
{
    /// <summary>
    /// (Creates a new company along with its associated user account in a single operation).
    /// </summary>
    /// <param name="company">
    /// The input model containing company and user registration details.
    /// </param>
    /// <returns>
    /// A <see cref="Result"/> indicating whether the operation succeeded.
    /// Returns failure if user creation or company persistence fails.
    /// </returns>
    Task<Result> CreateCompanyAsync(CompanyViewModel company);
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="company"></param>
    /// <returns></returns>
    Task<Result> UpdateCompanyAsync(CompanyViewModel company);
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="companyId"></param>
    /// <returns>
    /// A <see cref="Result<CompanyViewModel>"/> indicating whether the operation succeeded.
    /// Returns failure if user creation or company persistence fails.
    /// </returns>
    Task<Result<CompanyViewModel>> GetCompanyAsync(Guid companyId);
    
    
    /// <summary>
    /// Deletes the company with the specific Id.
    /// </summary>
    /// <param name="company">Company's unique identity</param>
    /// <returns>
    /// A <see cref="Result"/> indicating whether the operation succeeded.
    /// Returns failure if user creation or company persistence fails.
    /// </returns>
    Task<Result> DeleteCompanyAsync(Guid company);
}