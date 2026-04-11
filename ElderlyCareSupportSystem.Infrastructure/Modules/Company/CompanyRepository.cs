using Dapper;
using ElderlyCareSupport.Domain.Entities;
using ElderlyCareSupportSystem.Application.Modules.Company.Contracts;
using ElderlyCareSupportSystem.Infrastructure.Persistence.Data;

namespace ElderlyCareSupportSystem.Infrastructure.Persistence.Repository;

public sealed class CompanyRepository : ICompanyRepository
{
    private readonly ElderlyCareSupportDbContext _dbContext;
    private readonly DapperDbContext _dapperDbContext;
    public CompanyRepository(ElderlyCareSupportDbContext dbContext, DapperDbContext dapperDbContext)
    {
        _dbContext = dbContext;
        _dapperDbContext = dapperDbContext;
    }

    public async Task<Company> AddAsync(Company company)
    {
        await _dbContext.Companies.AddAsync(company);
        await _dbContext.SaveChangesAsync();
        return company;
    }

    public async Task<Company?> UpdateAsync(Company company)
    {
        _dbContext.Companies.Update(company);
        await _dbContext.SaveChangesAsync();
        return company;
    }

    public async Task<Company?> GetAsync(Guid companyId)
    {
        using var connection = _dapperDbContext.CreateConnection();
        return await connection.QueryFirstOrDefaultAsync<Company>("""
                                                            SELECT * FROM "Companies" WHERE ID = @Id);
                                                            """, new { Id = companyId });
    }

    public async Task<Company> DeleteAsync(Company company)
    {
        _dbContext.Companies.Remove(company);
        await _dbContext.SaveChangesAsync();
        return company;
    }
}