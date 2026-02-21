using ElderlyCareSupport.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ElderlyCareSupportSystem.Infraustructure.Persistence;

public class ApplicationDbContext : IdentityDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options) 
    {
    }
    
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<Company>()
            .HasOne(c => c.CreatedBy)
            .WithMany()
            .HasForeignKey(c => c.CreatedById)
            .OnDelete(DeleteBehavior.Restrict); // <-- prevent cascade

        builder.Entity<Company>()
            .HasOne(c => c.UpdatedBy)
            .WithMany()
            .HasForeignKey(c => c.UpdatedById)
            .OnDelete(DeleteBehavior.Restrict); // <-- prevent cascade
    }
    
    public DbSet<Company> Companies { get; set; }
}