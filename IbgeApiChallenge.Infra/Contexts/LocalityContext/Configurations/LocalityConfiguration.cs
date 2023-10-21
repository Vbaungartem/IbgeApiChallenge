using IbgeApiChallenge.Core.Contexts.StateContext.Entitties;
using IbgeApiChallenge.Core.Contexts.UserContext.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IbgeApiChallenge.Infra.Contexts.LocalityContext.Configurations;

public class LocalityConfiguration : IEntityTypeConfiguration<Locality>
{
    public void Configure(EntityTypeBuilder<Locality> builder)
    {
        const string tableName = "localities";

        builder.ToTable(tableName);

        builder.HasKey(locality => locality.Id);

        builder.Property(locality => locality.StateId)
            .HasColumnName("state_id")
            .HasColumnType("uniqueidentifier ")
            .HasMaxLength(2)
            .IsRequired();

        builder.Property(state => state.IbgeCode)
            .HasColumnName("ibge_code")
            .HasColumnType("NVARCHAR")
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(locality => locality.Name)
            .HasColumnName("name")
            .HasColumnType("NVARCHAR")
            .HasMaxLength(100)
            .IsRequired();

        builder.HasOne<State>(locality => locality.State)
            .WithMany(state => state.LocalityList)
            .HasForeignKey(locality => locality.StateId)
            .HasPrincipalKey(state => state.Id);
    }

}
