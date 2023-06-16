using System.Linq.Expressions;
using PetClinic.DAL.Interfaces.Entities;

namespace PetClinic.DAL.Tests.TestEntities;

public abstract class EntitiesGenerator<TEntity>
    where TEntity : IEntity<Guid>
{
    public abstract TEntity GetValidEntity();

    public abstract IEnumerable<TEntity> GetValidEntitiesList();

    public abstract IEnumerable<TEntity> GetEntitiesForSearch();

    public abstract Expression<Func<TEntity, bool>> GetFilterForSearch();

    public abstract void UpdateEntity(TEntity entity);

    public abstract TEntity CloneEntity(TEntity entity);

}