using PetClinic.DAL.Entities;
using PetClinic.DAL.Interfaces.Repositories;
using System.Linq.Expressions;


namespace PetClinic.DAL.Repositories;

public class ServiceVetRepository : IRepository<ServiceVetEntity, Guid>
{
    protected readonly AppDbContext Context;

    public ServiceVetRepository(AppDbContext context)
    {
        Context = context;
    }
    public void Add(ServiceVetEntity entity)
    {
        Context.Set<ServiceVetEntity>().Add(entity);
    }

    public void AddRange(IEnumerable<ServiceVetEntity> entities)
    {
        Context.Set<ServiceVetEntity>().AddRange(entities);
    }

    public IQueryable<ServiceVetEntity> Find(Expression<Func<ServiceVetEntity, bool>> predicate)
    {
        return Context.Set<ServiceVetEntity>().Where(predicate);
    }

    public ServiceVetEntity? Get(Guid id)
    {
        return Context.Set<ServiceVetEntity>().Find(id);
    }

    public IQueryable<ServiceVetEntity> GetAll()
    {
        return Context.Set<ServiceVetEntity>().AsQueryable<ServiceVetEntity>();
    }

    public void Remove(ServiceVetEntity entity)
    {
        Context.Set<ServiceVetEntity>().Remove(entity);
    }

    public void RemoveRange(IEnumerable<ServiceVetEntity> entities)
    {
        Context.Set<ServiceVetEntity>().RemoveRange(entities);
    }
}
