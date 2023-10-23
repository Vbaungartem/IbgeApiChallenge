using IbgeApiChallenge.Core.Contexts.StateContext.Entitties;
using IbgeApiChallenge.Core.Contexts.StateContext.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IbgeApiChallenge.Infra.Contexts.StateContext.Configurations;

public class StateConfiguration : IEntityTypeConfiguration<State>
{
    public void Configure(EntityTypeBuilder<State> builder)
    {
        const string tableName = "states";

        builder.ToTable(tableName);

        builder.HasKey(state => state.Id);

        builder.Property(state => state.Name)
            .HasColumnName("name")
            .HasColumnType("NVARCHAR")
            .HasMaxLength(50)
            .IsRequired();
        
        builder.Property(state => state.IbgeCode)
            .HasColumnName("ibge_code")
            .HasColumnType("NVARCHAR")
            .HasMaxLength(2)
            .IsRequired();
        
        builder.Property(state => state.Acronym)
            .HasColumnName("acronym")
            .HasColumnType("VARCHAR")
            .HasMaxLength(2)
            .IsRequired();
        
        // builder.OwnsOne(state => state.IbgeCode)
        //     .Property(ibgeCode => ibgeCode.Code)
        //     .HasColumnName("ibge_code")
        //     .IsRequired();
        
        // builder.OwnsOne(state => state.Acronym)
        //     .Property(acronym => acronym)
        //     .HasColumnName("acronym")
            
            
    }

}
