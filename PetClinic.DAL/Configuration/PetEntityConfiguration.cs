using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetClinic.DAL.Entities;

namespace PetClinic.DAL.Configuration;

public class PetEntityConfiguration : IEntityTypeConfiguration<PetEntity>
{
    public void Configure(EntityTypeBuilder<PetEntity> builder)
    {
        builder.HasKey(p => p.Id);

        builder.HasOne(p => p.User)
               .WithMany(u => u.Pets)
               .HasForeignKey(p => p.ClientId);

        builder.HasOne(p => p.PetType)
               .WithMany(pt => pt.Pets)
               .HasForeignKey(p => p.PetTypeId)
               .IsRequired();
        
        builder.Property(r => r.Id).ValueGeneratedOnAdd();
        builder.Property(p => p.Name).HasMaxLength(20);
    }
}
