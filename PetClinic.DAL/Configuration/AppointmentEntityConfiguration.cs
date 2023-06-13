using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetClinic.DAL.Entities;

namespace PetClinic.DAL.Configuration;

public class AppointmentEntityConfiguration : IEntityTypeConfiguration<AppointmentEntity>
{
    public void Configure(EntityTypeBuilder<AppointmentEntity> builder)
    {
        builder.HasKey(a => a.Id);

        builder.HasOne(a => a.Review)
               .WithOne(r => r.Appointment)
               .HasForeignKey<AppointmentEntity>(a => a.ReviewId);
            
        builder.HasOne(a => a.Pet)
               .WithMany(p => p.Appointments)
               .HasForeignKey(a => a.PetId)
               .IsRequired();

        builder.HasOne(a => a.Service)
               .WithMany(s => s.Appointments)
               .HasForeignKey(a => a.ServiceId)
               .IsRequired();

        builder.Property(r => r.Id).ValueGeneratedOnAdd();
    }
}
