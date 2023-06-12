using PetClinic.DAL.Entities;
using PetClinic.DAL.Interfaces.Repositories;
using System.Linq.Expressions;

namespace PetClinic.DAL.Repositories;

public class ServiceRepository : IRepository<ServiceEntity, Guid>
{

    protected readonly AppDbContext Context;

    public ServiceRepository(AppDbContext context)
    {
        Context = context;
    }
    public void Add(ServiceEntity entity)
    {
        Context.Set<ServiceEntity>().Add(entity);
    }

    public void AddRange(IEnumerable<ServiceEntity> entities)
    {
        Context.Set<ServiceEntity>().AddRange(entities);
    }

    public IQueryable<ServiceEntity> Find(Expression<Func<ServiceEntity, bool>> predicate)
    {
        return Context.Set<ServiceEntity>().Where(predicate);
    }

    public ServiceEntity? Get(Guid id)
    {
        return Context.Set<ServiceEntity>().Find(id);
    }

    public IQueryable<ServiceEntity> GetAll()
    {
       return Context.Set<ServiceEntity>().AsQueryable<ServiceEntity>();
    }

    public void Remove(ServiceEntity entity)
    {
        Context.Set<ServiceEntity>().Remove(entity);
    }

    public void RemoveRange(IEnumerable<ServiceEntity> entities)
    {
        Context.Set<ServiceEntity>().RemoveRange(entities);
    }
}
