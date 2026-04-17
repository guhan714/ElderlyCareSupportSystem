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
    
    Task<Result> UpdateCompanyAsync(CompanyViewModel company);
    
    Task<Result<CompanyViewModel>> GetCompanyAsync(Guid companyId);
    
    Task<Result> DeleteCompanyAsync(Guid company);
}