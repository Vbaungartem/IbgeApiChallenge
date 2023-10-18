using IbgeApiChallenge.Core.Contexts.UserContext.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IbgeApiChallenge.Infra.Contexts.UserContext.Configurations;

public class RoleConfiguration : IEntityTypeConfiguration<Role>
{
    public void Configure(EntityTypeBuilder<Role> builder)
    {
        const string tableName = "auth_roles";

        builder.ToTable(tableName);

        builder.HasKey(role => role.Id);

        builder.Property(role => role.Name)
            .HasColumnName("name")
            .HasColumnType("NVARCHAR")
            .HasMaxLength(150)
            .IsRequired();
    }
}