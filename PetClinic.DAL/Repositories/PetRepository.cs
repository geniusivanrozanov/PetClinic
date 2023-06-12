using PetClinic.DAL.Entities;
using PetClinic.DAL.Interfaces.Repositories;
using System.Linq.Expressions;


namespace PetClinic.DAL.Repositories;

public class PetRepository : IRepository<PetEntity, Guid>
{
    protected readonly AppDbContext Context;

    public PetRepository(AppDbContext context)
    {
        Context = context;
    }
    public void Add(PetEntity entity)
    {
        Context.Set<PetEntity>().Add(entity);
    }

    public void AddRange(IEnumerable<PetEntity> entities)
    {
        Context.Set<PetEntity>().AddRange(entities);
    }

    public IQueryable<PetEntity> Find(Expression<Func<PetEntity, bool>> predicate)
    {
        return Context.Set<PetEntity>().Where(predicate);
    }

    public PetEntity? Get(Guid id)
    {
        return Context.Set<PetEntity>().Find(id);
    }

    public IQueryable<PetEntity> GetAll()
    {
        return Context.Set<PetEntity>().AsQueryable<PetEntity>();
    }

    public void Remove(PetEntity entity)
    {
        Context.Set<PetEntity>().Remove(entity);
    }

    public void RemoveRange(IEnumerable<PetEntity> entities)
    {
        Context.Set<PetEntity>().RemoveRange(entities);
    }
}
