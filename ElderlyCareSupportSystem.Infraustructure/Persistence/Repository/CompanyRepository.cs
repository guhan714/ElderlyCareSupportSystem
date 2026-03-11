using ElderlyCareSupport.Domain.Entities;
using ElderlyCareSupportSystem.Application.Interface.Repository;
using ElderlyCareSupportSystem.Infrastructure.Persistence.Data;

namespace ElderlyCareSupportSystem.Infrastructure.Persistence.Repository;

public sealed class CompanyRepository : ICompanyRepository
{
    private readonly ElderlyCareSupportDbContext _dbContext;

    public CompanyRepository(ElderlyCareSupportDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Company> AddAsync(Company company)
    {
        await _dbContext.Companies.AddAsync(company);
        await _dbContext.SaveChangesAsync();
        return company;
    }

    public Task<Company?> UpdateAsync(Company company)
    {
        throw new NotImplementedException();
    }

    public ValueTask<Company?> GetAsync(Guid companyId)
    {
        return _dbContext.Companies.FindAsync(companyId);
    }

    public async Task<Company> DeleteAsync(Company company)
    {
        _dbContext.Companies.Remove(company);
        await _dbContext.SaveChangesAsync();
        return company;
    }
}