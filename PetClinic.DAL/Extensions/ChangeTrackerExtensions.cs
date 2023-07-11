using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using PetClinic.DAL.Interfaces.Entities;

namespace PetClinic.DAL.Extensions;

public static class ChangeTrackerExtensions
{
    public static void SetAuditProperties(this ChangeTracker changeTracker)
    {
        var currentTime = DateTime.UtcNow;

        var deletableEntries = changeTracker
            .Entries()
            .Where(entry => entry.Entity is IUpdatedAt && entry.State is EntityState.Deleted);
        foreach (var entityEntry in deletableEntries)
        {
            var entity = (IDeletable)entityEntry.Entity;
            entityEntry.State = EntityState.Modified;
            entity.IsDeleted = true;
        }
        
        var creatableEntries = changeTracker
            .Entries()
            .Where(entry => entry.Entity is ICreatedAt && entry.State is EntityState.Added);
        foreach (var entityEntry in creatableEntries)
        {
            var entity = (ICreatedAt)entityEntry.Entity;
            entity.CreatedAt = currentTime;
        }
        
        var updatableEntries = changeTracker
            .Entries()
            .Where(entry => entry.Entity is IUpdatedAt && entry.State is EntityState.Added or EntityState.Modified);
        foreach (var entityEntry in updatableEntries)
        {
            var entity = (IUpdatedAt)entityEntry.Entity;
            entity.UpdatedAt = currentTime;
        }
    }
}
