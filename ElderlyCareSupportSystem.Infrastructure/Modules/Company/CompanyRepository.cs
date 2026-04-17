using Dapper;
using ElderlyCareSupportSystem.Application.Modules.Company.Contracts;
using ElderlyCareSupportSystem.Application.Modules.CompanyModule.Contracts;
using ElderlyCareSupportSystem.Infrastructure.Persistence.Data;

namespace ElderlyCareSupportSystem.Infrastructure.Modules.Company;

public sealed class CompanyRepository : ICompanyRepository
{
    private readonly ElderlyCareSupportDbContext _dbContext;
    private readonly DapperDbContext _dapperDbContext;
    public CompanyRepository(ElderlyCareSupportDbContext dbContext, DapperDbContext dapperDbContext)
    {
        _dbContext = dbContext;
        _dapperDbContext = dapperDbContext;
    }

    public async Task<ElderlyCareSupport.Domain.Entities.Company> AddAsync(ElderlyCareSupport.Domain.Entities.Company company)
    {
        await _dbContext.Companies.AddAsync(company);
        return company;
    }

    public async Task<ElderlyCareSupport.Domain.Entities.Company?> UpdateAsync(ElderlyCareSupport.Domain.Entities.Company company)
    {
        _dbContext.Companies.Update(company);
        await _dbContext.SaveChangesAsync();
        return company;
    }

    public async Task<ElderlyCareSupport.Domain.Entities.Company?> GetAsync(Guid companyId)
    {
        using var connection = _dapperDbContext.CreateConnection();
        return await connection.QueryFirstOrDefaultAsync<ElderlyCareSupport.Domain.Entities.Company>("""
            SELECT * FROM "Companies" WHERE ID = @Id);
            """, new { Id = companyId });
    }

    public async Task<ElderlyCareSupport.Domain.Entities.Company> DeleteAsync(ElderlyCareSupport.Domain.Entities.Company company)
    {
        _dbContext.Companies.Remove(company);
        await _dbContext.SaveChangesAsync();
        return company;
    }
}