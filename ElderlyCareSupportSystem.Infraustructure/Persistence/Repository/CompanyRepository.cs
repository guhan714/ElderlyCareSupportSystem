using ElderlyCareSupport.Domain.Entities;
using ElderlyCareSupportSystem.Application.Interface.Repository;
using Microsoft.EntityFrameworkCore;

namespace ElderlyCareSupportSystem.Infraustructure.Persistence.Repository;

public sealed class CompanyRepository : ICompanyRepository
{
    private readonly ApplicationDbContext _context;

    public CompanyRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Company?> AddAsync(Company company)
    {
        await _context.Companies.AddAsync(company);
        await _context.SaveChangesAsync();
        return company;
    }

    public async Task<Company?> UpdateAsync(Company company)
    {
        _context.Update(company);
        await _context.SaveChangesAsync();
        return company;
    }

    public async Task<Company?> GetAsync(Guid companyId)
    {
        return await _context.Companies.FindAsync(companyId);
    }

    public async Task<Company?> DeleteAsync(Company company)
    {
        _context.Companies.Remove(company);
        await _context.SaveChangesAsync();
        return company;
    }
}