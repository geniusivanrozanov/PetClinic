using Microsoft.EntityFrameworkCore;
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
    public async Task AddAsync(TEntity entity) => await _context.Set<TEntity>().AddAsync(entity);

    public async Task AddRangeAsync(IEnumerable<TEntity> entities) => await _context.Set<TEntity>().AddRangeAsync(entities);

    public async  Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate) => await _context.Set<TEntity>().Where(predicate).ToListAsync();

    public async Task<TEntity?> GetAsync(TId id) => await _context.Set<TEntity>().FindAsync(id);

    public async Task<IEnumerable<TEntity>> GetAllAsync() => await _context.Set<TEntity>().ToListAsync();

    public void Remove(TEntity entity) =>  _context.Set<TEntity>().Remove(entity);

    public void RemoveRange(IEnumerable<TEntity> entities) => _context.Set<TEntity>().RemoveRange(entities);

    public void Update(TEntity entity) => _context.Set<TEntity>().Update(entity);
}
  