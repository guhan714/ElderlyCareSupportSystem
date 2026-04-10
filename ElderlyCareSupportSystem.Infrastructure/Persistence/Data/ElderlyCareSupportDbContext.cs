using ElderlyCareSupport.Domain.Entities;
using ElderlyCareSupport.Domain.Entities.Identity;
using Microsoft.EntityFrameworkCore;

namespace ElderlyCareSupportSystem.Infrastructure.Persistence.Data;

public class ElderlyCareSupportDbContext : DbContext
{
    
    public ElderlyCareSupportDbContext(DbContextOptions<ElderlyCareSupportDbContext> options)
        : base(options)
    {
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Company>()
            .HasOne(c => c.CreatedBy)
            .WithMany()
            .HasForeignKey(c => c.CreatedById)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Company>()
            .HasOne(c => c.UpdatedBy)
            .WithMany()
            .HasForeignKey(c => c.UpdatedById)
            .OnDelete(DeleteBehavior.Restrict);
        
        modelBuilder.Entity<Role>()
            .HasOne(c => c.CreatedBy)
            .WithMany()
            .HasForeignKey(c => c.CreatedById)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Role>()
            .HasOne(c => c.ModifiedBy)
            .WithMany()
            .HasForeignKey(c => c.ModifiedById)
            .OnDelete(DeleteBehavior.Restrict);
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Role> Roles { get; set; }
    
    
    public DbSet<Country> Countries { get; set; }
    
    
    public DbSet<Company> Companies { get; set; }

}