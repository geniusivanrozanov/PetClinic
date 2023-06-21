using PetClinic.DAL.Interfaces.Entities;
using System.Linq.Expressions;

namespace PetClinic.DAL.Interfaces.Repositories;

public interface IRepository<TEntity, TId>  where TEntity : IEntity<TId>
{
    Task<TEntity?> GetAsync(TId id);
    Task<IEnumerable<TEntity>> GetAllAsync();
    Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate);
    Task<TEntity> AddAsync(TEntity entity);
    Task AddRangeAsync(IEnumerable<TEntity> entities);
    void Remove(TEntity entity);
    void RemoveRange(IEnumerable<TEntity> entities);
    TEntity Update(TEntity entity);
}
