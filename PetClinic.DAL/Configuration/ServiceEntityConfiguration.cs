using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetClinic.DAL.Entities;

namespace PetClinic.DAL.Configuration;

public class ServiceEntityConfiguration : IEntityTypeConfiguration<ServiceEntity>
{
    public void Configure(EntityTypeBuilder<ServiceEntity> builder)
    {
        builder.Property(r => r.Id).ValueGeneratedOnAdd();
        builder.Property(p => p.Name).HasMaxLength(100);
    }
}
