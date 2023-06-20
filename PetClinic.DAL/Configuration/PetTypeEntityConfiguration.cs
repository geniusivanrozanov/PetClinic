using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetClinic.DAL.Entities;

namespace PetClinic.DAL.Configuration;

public class PetTypeEntityConfiguration : IEntityTypeConfiguration<PetTypeEntity>
{
    public void Configure(EntityTypeBuilder<PetTypeEntity> builder)
    {
        builder.Property(r => r.Id).ValueGeneratedOnAdd();
        builder.Property(p => p.Name).HasMaxLength(20);
    }
}

