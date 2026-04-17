using Dapper;
using ElderlyCareSupportSystem.Application.Modules.Country.Contracts;
using ElderlyCareSupportSystem.Infrastructure.Persistence.Data;

namespace ElderlyCareSupportSystem.Infrastructure.Modules.Country;

public sealed class CountryRepository : ICountryRepository
{
    private readonly DapperDbContext _dbContext;

    public CountryRepository(DapperDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<ElderlyCareSupport.Domain.Entities.Country>> GetListAsync()
    {
        using var connection = _dbContext.CreateConnection();
        var countries = await connection.QueryAsync<ElderlyCareSupport.Domain.Entities.Country>(
            """SELECT "Id", "Name" FROM "Countries" ORDER BY "Name" ASC;"""
        );
        return countries.ToList();
    }
}