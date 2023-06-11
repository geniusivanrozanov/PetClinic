using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PetClinic.DAL.Entities;
using PetClinic.DAL.Extensions;

namespace PetClinic.DAL.DbContext;

public class AppDbContext : IdentityDbContext<UserEntity, RoleEntity, Guid>
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<ServiceEntity> Services { get; set; } = default!;
    public DbSet<VetEntity> Vets { get; set; } = default!;
    public DbSet<AppointmentEntity> Appointments { get; set; } = default!;
    public DbSet<PetEntity> Pets { get; set; } = default!;
    public DbSet<DepartmentEntity> Departments { get; set; } = default!;
    public DbSet<PetTypeEntity> PetTypes { get; set; } = default!;
    public DbSet<ReviewEntity> Reviews { get; set; } = default!;
    public DbSet<StatusEntity> Statuses { get; set; } = default!;
    public DbSet<OrderCallEntity> OrderCalls { get; set; } = default!;
    public DbSet<ServiceVetEntity> ServiceVets { get; set; } = default!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.AddExtentions();
    }
}
