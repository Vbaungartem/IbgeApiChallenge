using IbgeApiChallenge.Core.Contexts.StateContext.Entitties;
using IbgeApiChallenge.Core.Contexts.UserContext.Entities;
using IbgeApiChallenge.Infra.Contexts.LocalityContext.Configurations;
using IbgeApiChallenge.Infra.Contexts.StateContext.Configurations;
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
    public DbSet<State> State { get; set; } = null!;
    public DbSet<Locality> Locality { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new UserConfiguration());
        modelBuilder.ApplyConfiguration(new RoleConfiguration());
        modelBuilder.ApplyConfiguration(new StateConfiguration());
        modelBuilder.ApplyConfiguration(new LocalityConfiguration());
    }
}