using System.Data;
using Microsoft.Extensions.Configuration;
using Npgsql;

namespace ElderlyCareSupportSystem.Infrastructure.Persistence.Data;

public class DapperDbContext : IDisposable
{
    private readonly string? _connectionString;
    public DapperDbContext(string connectionString)
    {
        _connectionString = connectionString;
    }
    
    public DapperDbContext(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("DefaultConnection");
    }
    
    public IDbConnection CreateConnection() => new NpgsqlConnection(_connectionString);

    public void Dispose()
    {
        
    }
}