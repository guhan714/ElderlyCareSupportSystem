using ElderlyCareSupportSystem.Application.Modules.Common.Contracts;
using ElderlyCareSupportSystem.Application.Modules.Company.Contracts;
using ElderlyCareSupportSystem.Application.Modules.Country.Contracts;
using ElderlyCareSupportSystem.Application.Modules.User.Contracts;
using ElderlyCareSupportSystem.Infrastructure.Modules.Company;
using ElderlyCareSupportSystem.Infrastructure.Modules.Country;
using ElderlyCareSupportSystem.Infrastructure.Modules.User;
using ElderlyCareSupportSystem.Infrastructure.Persistence.Data;
using Microsoft.EntityFrameworkCore.Storage;

namespace ElderlyCareSupportSystem.Infrastructure.Modules.Common.Implementation;

public sealed class UnitOfWork : IUnitOfWork
{
    private readonly ElderlyCareSupportDbContext _dbContext;
    private readonly DapperDbContext _dapperDbContext;
    private IDbContextTransaction? _transaction;

    public UnitOfWork(ElderlyCareSupportDbContext dbContext, DapperDbContext dapperDbContext)
    {
        _dbContext = dbContext;
        _dapperDbContext = dapperDbContext;
    }

    public ICompanyRepository Companies => new CompanyRepository(_dbContext, _dapperDbContext);
    public IUserRepository Users => new UserRepository(_dbContext, _dapperDbContext);
    public ICountryRepository Countries => new CountryRepository(_dapperDbContext);

    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return await _dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task<bool> BeginTransactionAsync()
    {
        _transaction = await _dbContext.Database.BeginTransactionAsync();
        return true;
    }

    public async Task<bool> CommitAsync()
    {
        try
        {
            await _dbContext.SaveChangesAsync();
            await _transaction?.CommitAsync()!;
            return true;
        }
        catch
        {
            await _transaction?.RollbackAsync()!;
            throw;
        }
    }

    public async Task<bool> RollbackAsync()
    {
        await _transaction?.RollbackAsync()!;
        return true;
    }

    public async ValueTask DisposeAsync()
    {
        _transaction?.Dispose();
        await _dbContext.DisposeAsync();
    }
}