using PetClinic.DAL.Entities;
using PetClinic.DAL.Interfaces.Repositories;
using System.Linq.Expressions;


namespace PetClinic.DAL.Repositories;

public class VetRepository : IRepository<VetEntity, Guid>
{
    protected readonly AppDbContext Context;

    public VetRepository(AppDbContext context)
    {
        Context = context;
    }
    public void Add(VetEntity entity)
    {
        Context.Set<VetEntity>().Add(entity);
    }

    public void AddRange(IEnumerable<VetEntity> entities)
    {
        Context.Set<VetEntity>().AddRange(entities);
    }

    public IQueryable<VetEntity> Find(Expression<Func<VetEntity, bool>> predicate)
    {
        return Context.Set<VetEntity>().Where(predicate);
    }

    public VetEntity? Get(Guid id)
    {
        return Context.Set<VetEntity>().Find(id);
    }

    public IQueryable<VetEntity> GetAll()
    {
        return Context.Set<VetEntity>().AsQueryable<VetEntity>();
    }

    public void Remove(VetEntity entity)
    {
        Context.Set<VetEntity>().Remove(entity);
    }

    public void RemoveRange(IEnumerable<VetEntity> entities)
    {
        Context.Set<VetEntity>().RemoveRange(entities);
    }
}
