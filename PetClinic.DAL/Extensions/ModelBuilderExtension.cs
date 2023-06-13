using Microsoft.EntityFrameworkCore;
using PetClinic.DAL.Configuration;
using PetClinic.DAL.Entities;

namespace PetClinic.DAL.Extensions;

public static class ModelBuilderExtension
{
    public static void AddExtensions(this ModelBuilder modelBuilder)
    {
        modelBuilder.AddConfiguration();
        modelBuilder.SetEntitiesRelations();
        modelBuilder.SetPropertiesSettingsInEntities();
    }

    private static void AddConfiguration(this ModelBuilder modelBuilder)
    { 
        modelBuilder.ApplyConfiguration(new DepartmentEntityConfiguration());
        modelBuilder.ApplyConfiguration(new PetTypeEntityConfiguration());
        modelBuilder.ApplyConfiguration(new StatusEntityConfiguration());
    }

    private static void SetEntitiesRelations(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<PetEntity>().HasKey(p => p.Id);
        modelBuilder.Entity<PetEntity>()
            .HasOne(p => p.User)
            .WithMany(u => u.Pets)
            .HasForeignKey(p => p.ClientId);

        modelBuilder.Entity<PetEntity>()
            .HasOne(p => p.PetType)
            .WithMany(pt => pt.Pets)
            .HasForeignKey(p => p.PetTypeId)
            .IsRequired();
        
        modelBuilder.Entity<ServiceVetEntity>()
            .HasKey(sv => sv.Id);

        modelBuilder.Entity<ServiceVetEntity>()
            .HasOne(sv => sv.Service)
            .WithMany(s => s.ServiceVets)
            .HasForeignKey(sv => sv.ServiceId);
        
        modelBuilder.Entity<ServiceVetEntity>()
            .HasOne(sv => sv.Vet)
            .WithMany(s => s.ServiceVets)
            .HasForeignKey(sv => sv.VetId);
        
        modelBuilder.Entity<VetEntity>().HasKey(v => v.Id);
        modelBuilder.Entity<VetEntity>()
            .HasOne(v => v.Department)
            .WithMany(v => v.Vets)
            .HasForeignKey(v => v.DepartmentId)
            .IsRequired();
        
        modelBuilder.Entity<VetEntity>()
            .HasOne(v => v.User)
            .WithOne(c => c.Vet)
            .HasForeignKey<VetEntity>(v => v.ClientId);

        modelBuilder.Entity<OrderCallEntity>().HasKey(oc => oc.Id);
        modelBuilder.Entity<OrderCallEntity>()
            .HasOne(oc => oc.Status)
            .WithMany(s => s.OrderCalls)
            .HasForeignKey(oc => oc.StatusId)
            .IsRequired();

        modelBuilder.Entity<AppointmentEntity>().HasKey(a => a.Id);
        modelBuilder.Entity<AppointmentEntity>()
            .HasOne(a => a.Review)
            .WithOne(r => r.Appointment)
            .HasForeignKey<AppointmentEntity>(a => a.ReviewId);
            
        modelBuilder.Entity<AppointmentEntity>()
            .HasOne(a => a.Pet)
            .WithMany(p => p.Appointments)
            .HasForeignKey(a => a.PetId)
            .IsRequired();

        modelBuilder.Entity<AppointmentEntity>()
            .HasOne(a => a.Service)
            .WithMany(s => s.Appointments)
            .HasForeignKey(a => a.ServiceId)
            .IsRequired();
    }

    private static void SetPropertiesSettingsInEntities(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<RoleEntity>().Property(r => r.Id).ValueGeneratedOnAdd();
        modelBuilder.Entity<AppointmentEntity>().Property(r => r.Id).ValueGeneratedOnAdd();
        modelBuilder.Entity<DepartmentEntity>().Property(r => r.Id).ValueGeneratedOnAdd();
        modelBuilder.Entity<OrderCallEntity>().Property(r => r.Id).ValueGeneratedOnAdd();
        modelBuilder.Entity<PetEntity>().Property(r => r.Id).ValueGeneratedOnAdd();
        modelBuilder.Entity<PetTypeEntity>().Property(r => r.Id).ValueGeneratedOnAdd();
        modelBuilder.Entity<ReviewEntity>().Property(r => r.Id).ValueGeneratedOnAdd();
        modelBuilder.Entity<RoleEntity>().Property(r => r.Id).ValueGeneratedOnAdd();
        modelBuilder.Entity<ServiceEntity>().Property(r => r.Id).ValueGeneratedOnAdd();
        modelBuilder.Entity<ServiceVetEntity>().Property(r => r.Id).ValueGeneratedOnAdd();
        modelBuilder.Entity<StatusEntity>().Property(r => r.Id).ValueGeneratedOnAdd();
        modelBuilder.Entity<UserEntity>().Property(r => r.Id).ValueGeneratedOnAdd();
        modelBuilder.Entity<VetEntity>().Property(r => r.Id).ValueGeneratedOnAdd();

        modelBuilder.Entity<DepartmentEntity>().Property(d => d.Address).HasMaxLength(50);
        modelBuilder.Entity<DepartmentEntity>().Property(d => d.Name).HasMaxLength(30);
        modelBuilder.Entity<OrderCallEntity>().Property(oc => oc.PhoneNumber).HasMaxLength(15);
        modelBuilder.Entity<PetEntity>().Property(p => p.Name).HasMaxLength(20);
        modelBuilder.Entity<PetTypeEntity>().Property(p => p.Name).HasMaxLength(20);
        modelBuilder.Entity<ReviewEntity>().Property(p => p.Diagnosis).HasMaxLength(300);
        modelBuilder.Entity<ReviewEntity>().Property(p => p.VetComments).HasMaxLength(300);
        modelBuilder.Entity<ServiceEntity>().Property(p => p.Name).HasMaxLength(30);
        modelBuilder.Entity<StatusEntity>().Property(p => p.Name).HasMaxLength(20);
        modelBuilder.Entity<UserEntity>().Property(u => u.Email).HasMaxLength(30);
        modelBuilder.Entity<UserEntity>().Property(u => u.FirstName).HasMaxLength(30);
        modelBuilder.Entity<UserEntity>().Property(u => u.LastName).HasMaxLength(30);
        modelBuilder.Entity<UserEntity>().Property(u => u.PhoneNumber).HasMaxLength(15);
    }
}
