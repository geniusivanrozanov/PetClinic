using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetClinic.DAL.Entities;
using PetClinic.DAL.Interfaces.Entities;

namespace PetClinic.DAL.Extensions;

public static class ModelBuilderExtensions
{
    public static void ApplySoftDeletingGlobalFilter(this ModelBuilder modelBuilder)
    {
        foreach (var entityType in modelBuilder.Model.GetEntityTypes())
        {
            if (typeof(IDeletable).IsAssignableFrom(entityType.ClrType))
            {
                typeof(ModelBuilderExtensions)
                    .GetMethod(nameof(ApplySoftDeletingGlobalFilterFor))
                    ?.MakeGenericMethod(entityType.ClrType)
                    .Invoke(null, new object?[] { modelBuilder });
            }
        }
    }
    
    public static void ApplySoftDeletingGlobalFilterFor<TEntity>(this ModelBuilder modelBuilder)
        where TEntity: class, IDeletable
    {
        modelBuilder.Entity<TEntity>()
            .HasQueryFilter(e => !e.IsDeleted);
    }
}