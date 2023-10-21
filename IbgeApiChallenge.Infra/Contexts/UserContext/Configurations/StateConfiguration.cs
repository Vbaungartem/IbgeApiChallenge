using IbgeApiChallenge.Core.Contexts.UserContext.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IbgeApiChallenge.Infra.Contexts.UserContext.Configurations;

public class StateConfiguration : IEntityTypeConfiguration<State>
{
    public void Configure(EntityTypeBuilder<State> builder)
    {
        const string tableName = "states";

        builder.ToTable(tableName);

        builder.HasKey(state => state.Id);

        builder.HasAlternateKey(state => state.IbgeCode);

        builder.Property(state => state.IbgeCode)
            .HasColumnName("ibge_code")
            .HasColumnType("NVARCHAR")
            .HasMaxLength(2)
            .IsRequired();

        builder.Property(state => state.Name)
            .HasColumnName("name")
            .HasColumnType("NVARCHAR")
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(state => state.Acronym)
            .HasColumnName("acronym")
            .HasColumnType("NVARCHAR")
            .HasMaxLength(2)
            .IsRequired();
    }
}
