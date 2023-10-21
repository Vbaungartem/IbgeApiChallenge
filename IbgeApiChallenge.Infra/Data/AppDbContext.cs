using IbgeApiChallenge.Core.Contexts.UserContext.Entities;
using IbgeApiChallenge.Infra.Contexts.UserContext.Configurations;
using Microsoft.EntityFrameworkCore;

namespace IbgeApiChallenge.Infra.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }
    
    public DbSet<User?> User { get; set; } = null!;
    public DbSet<Role> Role { get; set; } = null!;
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new UserConfiguration());
        modelBuilder.ApplyConfiguration(new RoleConfiguration());
    }
}