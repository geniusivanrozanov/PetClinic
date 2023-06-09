using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PetClinic.DAL.Entities;

namespace PetClinic.DAL;

public class AppDbContext : DbContext // : IdentityDbContext<UserEntity>
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<ServiceEntity> Services { get; set; }
    public DbSet<VetEntity> Vets { get; set; }
    public DbSet<AppointmentEntity> Appointments { get; set; }
    public DbSet<PetEntity> Pets { get; set; }
    public DbSet<DepartmentEntity> Departments { get; set; }
    public DbSet<PetTypeEntity> PetTypes { get; set; }
    public DbSet<ReviewEntity> Reviews { get; set; }
    public DbSet<UserEntity> Users { get; set; }
    public DbSet<StatusEntity> Statuses { get; set; }
    public DbSet<RoleEntity> Roles { get; set; }
    public DbSet<OrderCallEntity> OrderCalls { get; set; }
    public DbSet<ServiceVetEntity> ServiceVets { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.AddExtentions();
    }
}
