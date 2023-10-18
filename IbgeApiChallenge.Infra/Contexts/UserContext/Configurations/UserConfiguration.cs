using IbgeApiChallenge.Core.Contexts.UserContext.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IbgeApiChallenge.Infra.Contexts.UserContext.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        const string tableName = "auth_users";

        builder.ToTable(tableName);

        builder.HasKey(user => user.Id);

        builder.Property(user => user.Name)
            .HasColumnName("name")
            .HasColumnType("NVARCHAR")
            .HasMaxLength(250)
            .IsRequired();
        
        builder.Property(user => user.GivenName)
            .HasColumnName("given_name")
            .HasColumnType("NVARCHAR")
            .HasMaxLength(250)
            .IsRequired();

        builder.OwnsOne(user => user.Email)
            .Property(email => email.Address)
            .HasColumnName("email")
            .HasColumnType("NVARCHAR")
            .HasMaxLength(250)
            .IsRequired();

        builder.OwnsOne(user => user.Password)
            .Property(pw => pw.Hash)
            .HasColumnName("password_hash")
            .IsRequired();

        builder.HasMany<Role>(user => user.Roles)
            .WithMany(roles => roles.Users)
            .UsingEntity<Dictionary<string, Object>>(
                "auth_users_x_roles",
                role =>
                    role.HasOne<Role>()
                        .WithMany()
                        .HasForeignKey("id_role")
                        .OnDelete(DeleteBehavior.Cascade),
                user =>
                    user.HasOne<User>()
                        .WithMany()
                        .HasForeignKey("id_user")
                        .OnDelete(DeleteBehavior.Cascade)
            );
    }
}
    
