using Microsoft.EntityFrameworkCore;
using PetClinic.DAL.Entities;

namespace PetClinic.DAL.Configuration;

public class VetEntityConfiguration : IEntityTypeConfiguration<VetEntity>
{
    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<VetEntity> builder)
    {
        builder.HasKey(v => v.Id);

        builder.HasOne(v => v.Department)
               .WithMany(v => v.Vets)
               .HasForeignKey(v => v.DepartmentId)
               .IsRequired();
        
        builder.HasOne(v => v.User)
               .WithOne(c => c.Vet)
               .HasForeignKey<VetEntity>(v => v.ClientId);
        
        builder.Property(r => r.Id).ValueGeneratedOnAdd();
    }
}
