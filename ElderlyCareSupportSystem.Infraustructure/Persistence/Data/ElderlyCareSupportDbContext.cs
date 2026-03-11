using ElderlyCareSupport.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ElderlyCareSupportSystem.Infrastructure.Persistence.Data;

public class ElderlyCareSupportDbContext : DbContext
{

    public ElderlyCareSupportDbContext(DbContextOptions<ElderlyCareSupportDbContext> options)
        : base(options)
    {
    }

    public DbSet<Company> Companies { get; set; }
}