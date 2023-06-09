using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PetClinic.DAL.Entities;

namespace PetClinic.DAL
{
    public static class ModelBuilderExtension
    {
        public static void AddExtentions(this ModelBuilder modelBuilder)
        {
            modelBuilder.AddConfiguration();
            modelBuilder.SetEntitiesRelations();
            modelBuilder.SetRequiredFieldsInEntities();
        }

        private static void AddConfiguration(this ModelBuilder modelBuilder)
        {

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

            modelBuilder.Entity<UserEntity>()
                .HasOne(u => u.Role)
                .WithMany(r => r.Users)
                .HasForeignKey(u => u.RoleId)
                .IsRequired();
        }

        private static void SetRequiredFieldsInEntities(this ModelBuilder modelBuilder)
        {
        }
    }
}
