using PetClinic.DAL.Interfaces.Entities;
using PetClinic.DAL.Interfaces.Repositories;
using System.Linq.Expressions;

namespace PetClinic.DAL.Repositories;

public abstract class BaseRepository<TEntity, TId> : IRepository<TEntity, TId> where TEntity : class, IEntity<TId>
{
    protected readonly AppDbContext _context;

    public BaseRepository(AppDbContext context)
    {
        _context = context;
    }
    public void Add(TEntity entity) => _context.Set<TEntity>().Add(entity);

    public void AddRange(IEnumerable<TEntity> entities) => _context.Set<TEntity>().AddRange(entities);

    public IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> predicate) => _context.Set<TEntity>().Where(predicate);

    public TEntity? Get(TId id) => _context.Set<TEntity>().Find(id);

    public IQueryable<TEntity> GetAll() => _context.Set<TEntity>().AsQueryable<TEntity>();

    public void Remove(TEntity entity) => _context.Set<TEntity>().Remove(entity);

    public void RemoveRange(IEnumerable<TEntity> entities) => _context.Set<TEntity>().RemoveRange(entities);

    public void Update(TEntity entity) => _context.Set<TEntity>().Update(entity);
}
  