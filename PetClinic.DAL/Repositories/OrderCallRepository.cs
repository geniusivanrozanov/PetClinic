using PetClinic.DAL.Entities;
using PetClinic.DAL.Interfaces.Repositories;
using System.Linq.Expressions;


namespace PetClinic.DAL.Repositories;

public class OrderCallRepository : IRepository<OrderCallEntity, Guid>
{
    protected readonly AppDbContext Context;

    public OrderCallRepository(AppDbContext context)
    {
        Context = context;
    }

    public void Add(OrderCallEntity entity)
    {
        Context.Set<OrderCallEntity>().Add(entity);
    }

    public void AddRange(IEnumerable<OrderCallEntity> entities)
    {
        Context.Set<OrderCallEntity>().AddRange(entities);
    }

    public IQueryable<OrderCallEntity> Find(Expression<Func<OrderCallEntity, bool>> predicate)
    {
        return Context.Set<OrderCallEntity>().Where(predicate);
    }

    public OrderCallEntity? Get(Guid id)
    {
        return Context.Set<OrderCallEntity>().Find(id);
    }

    public IQueryable<OrderCallEntity> GetAll()
    {
        return Context.Set<OrderCallEntity>().AsQueryable<OrderCallEntity>();
    }

    public void Remove(OrderCallEntity entity)
    {
        Context.Set<OrderCallEntity>().Remove(entity);
    }

    public void RemoveRange(IEnumerable<OrderCallEntity> entities)
    {
        Context.Set<OrderCallEntity>().RemoveRange(entities);
    }
}
