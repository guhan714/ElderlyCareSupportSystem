using ElderlyCareSupportSystem.Application.Modules.Company.Contracts;
using ElderlyCareSupportSystem.Application.Modules.CompanyModule.Contracts;
using ElderlyCareSupportSystem.Application.Modules.Country.Contracts;
using ElderlyCareSupportSystem.Application.Modules.User.Contracts;

namespace ElderlyCareSupportSystem.Application.Modules.Common.Contracts;

public interface IUnitOfWork : IAsyncDisposable
{
    ICompanyRepository Companies { get; }
    IUserRepository Users { get; }
    ICountryRepository Countries { get; }
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    Task<bool> BeginTransactionAsync();
    Task<bool> CommitAsync();
    Task<bool> RollbackAsync();
}