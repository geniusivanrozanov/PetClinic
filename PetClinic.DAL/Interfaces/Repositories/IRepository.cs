using PetClinic.DAL.Interfaces.Entities;
using System.Linq.Expressions;

namespace PetClinic.DAL.Interfaces.Repositories;

public interface IRepository<TEntity, TId>  where TEntity : IEntity<TId>
{
    TEntity? Get(TId id);
    IQueryable<TEntity> GetAll();
    IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);

    void Add(TEntity entity);
    void AddRange(IEnumerable<TEntity> entities);
    void Remove(TEntity entity);
    void RemoveRange(IEnumerable<TEntity> entities);
    void Update(TEntity entity);

}
