using PetClinic.DAL.Entities;
using PetClinic.DAL.Interfaces.Repositories;
using System.Linq.Expressions;


namespace PetClinic.DAL.Repositories;

public class PetTypeRepository : IRepository<PetTypeEntity, Guid>
{
    protected readonly AppDbContext Context;

    public PetTypeRepository(AppDbContext context)
    {
        Context = context;
    }

    public void Add(PetTypeEntity entity)
    {
        Context.Set<PetTypeEntity>().Add(entity);
    }

    public void AddRange(IEnumerable<PetTypeEntity> entities)
    {
        Context.Set<PetTypeEntity>().AddRange(entities);
    }

    public IQueryable<PetTypeEntity> Find(Expression<Func<PetTypeEntity, bool>> predicate)
    {
        return Context.Set<PetTypeEntity>().Where(predicate);
    }

    public PetTypeEntity? Get(Guid id)
    {
        return Context.Set<PetTypeEntity>().Find(id);
    }

    public IQueryable<PetTypeEntity> GetAll()
    {
        return Context.Set<PetTypeEntity>().AsQueryable<PetTypeEntity>();
    }

    public void Remove(PetTypeEntity entity)
    {
        Context.Set<PetTypeEntity>().Remove(entity);
    }

    public void RemoveRange(IEnumerable<PetTypeEntity> entities)
    {
        Context.Set<PetTypeEntity>().RemoveRange(entities);
    }
}
