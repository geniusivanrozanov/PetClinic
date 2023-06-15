using System.Reflection;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PetClinic.DAL.Entities;
using PetClinic.DAL.Interfaces.Entities;

namespace PetClinic.DAL;

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

    public override int SaveChanges(bool acceptAllChangesOnSuccess)
    {
        UpdateExtendedFields();
        
        return base.SaveChanges(acceptAllChangesOnSuccess);
    }

    public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = new CancellationToken())
    {
        UpdateExtendedFields();
        
        return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }

    private void UpdateExtendedFields()
    {
        var currentTime = DateTime.UtcNow;
        
        foreach (var entityEntry in ChangeTracker.Entries()
                     .Where(entry => entry.State == EntityState.Added))
        {
            if (entityEntry.Entity is ICreatedAt createdEntity)
            {
                createdEntity.CreatedAt = currentTime;
            }
            
            if (entityEntry.Entity is IUpdatedAt updatedEntity)
            {
                updatedEntity.UpdatedAt = currentTime;
            }
            
            if (entityEntry.Entity is IDeletable deletableEntity)
            {
                deletableEntity.IsDeleted = false;
            }
        }
        
        foreach (var entityEntry in ChangeTracker.Entries()
                     .Where(entry => entry.State == EntityState.Modified))
        {
            if (entityEntry.Entity is IUpdatedAt updatedEntity)
            {
                updatedEntity.UpdatedAt = currentTime;
            }
        }
        
        foreach (var entityEntry in ChangeTracker.Entries()
                     .Where(entry => entry.State == EntityState.Deleted))
        {
            if (entityEntry.Entity is IDeletable deletedEntity)
            {
                entityEntry.State = EntityState.Modified;
                deletedEntity.IsDeleted = true;
            }
        }
    }
}
