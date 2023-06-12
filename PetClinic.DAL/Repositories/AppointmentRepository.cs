using PetClinic.DAL.Entities;
using PetClinic.DAL.Interfaces.Repositories;
using System.Linq.Expressions;


namespace PetClinic.DAL.Repositories;

public class AppointmentRepository : IRepository<AppointmentEntity, Guid>
{
    protected readonly AppDbContext Context;

    public AppointmentRepository(AppDbContext context)
    {
        Context = context;
    }
    public void Add(AppointmentEntity entity)
    {
        Context.Set<AppointmentEntity>().Add(entity);
    }

    public void AddRange(IEnumerable<AppointmentEntity> entities)
    {
        Context.Set<AppointmentEntity>().AddRange(entities);
    }

    public IQueryable<AppointmentEntity> Find(Expression<Func<AppointmentEntity, bool>> predicate)
    {
        return Context.Set<AppointmentEntity>().Where(predicate);
    }

    public AppointmentEntity? Get(Guid id)
    {
        return Context.Set<AppointmentEntity>().Find(id);
    }

    public IQueryable<AppointmentEntity> GetAll()
    {
        return Context.Set<AppointmentEntity>().AsQueryable<AppointmentEntity>();
    }

    public void Remove(AppointmentEntity entity)
    {
        Context.Set<AppointmentEntity>().Remove(entity);
    }

    public void RemoveRange(IEnumerable<AppointmentEntity> entities)
    {
        Context.Set<AppointmentEntity>().RemoveRange(entities);
    }
}
