using PetClinic.DAL.Entities;
using PetClinic.DAL.Interfaces.Repositories;
using System.Linq.Expressions;


namespace PetClinic.DAL.Repositories;

public class ReviewRepository : IRepository<ReviewEntity, Guid>
{
    protected readonly AppDbContext Context;

    public ReviewRepository(AppDbContext context)
    {
        Context = context;
    }

    public void Add(ReviewEntity entity)
    {
        Context.Set<ReviewEntity>().Add(entity);
    }

    public void AddRange(IEnumerable<ReviewEntity> entities)
    {
        Context.Set<ReviewEntity>().AddRange(entities);
    }

    public IQueryable<ReviewEntity> Find(Expression<Func<ReviewEntity, bool>> predicate)
    {
        return Context.Set<ReviewEntity>().Where(predicate);
    }

    public ReviewEntity? Get(Guid id)
    {
        return Context.Set<ReviewEntity>().Find(id);
    }

    public IQueryable<ReviewEntity> GetAll()
    {
        return Context.Set<ReviewEntity>().AsQueryable<ReviewEntity>();
    }

    public void Remove(ReviewEntity entity)
    {
        Context.Set<ReviewEntity>().Remove(entity);
    }

    public void RemoveRange(IEnumerable<ReviewEntity> entities)
    {
        Context.Set<ReviewEntity>().RemoveRange(entities);
    }
}
