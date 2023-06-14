using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetClinic.DAL.Entities;

namespace PetClinic.DAL.Configuration;

public class ServiceVetEntityConfiguration : IEntityTypeConfiguration<ServiceVetEntity>
{
    public void Configure(EntityTypeBuilder<ServiceVetEntity> builder)
    {
        builder.HasKey(sv => sv.Id);

        builder.HasOne(sv => sv.Service)
               .WithMany(s => s.ServiceVets)
               .HasForeignKey(sv => sv.ServiceId);
        
        builder.HasOne(sv => sv.Vet)
               .WithMany(s => s.ServiceVets)
               .HasForeignKey(sv => sv.VetId);

        builder.Property(r => r.Id).ValueGeneratedOnAdd();
    }
}
