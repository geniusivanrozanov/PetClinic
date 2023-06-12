using PetClinic.DAL.Entities;
using PetClinic.DAL.Interfaces.Repositories;
using System.Linq.Expressions;

namespace PetClinic.DAL.Repositories;

public class DepartmentRepository : IRepository<DepartmentEntity, Guid>
{
    protected readonly AppDbContext Context;

    public DepartmentRepository(AppDbContext context)
    {
        Context = context;
    }
    public void Add(DepartmentEntity entity)
    {
        Context.Set<DepartmentEntity>().Add(entity);
    }

    public void AddRange(IEnumerable<DepartmentEntity> entities)
    {
        Context.Set<DepartmentEntity>().AddRange(entities);
    }

    public IQueryable<DepartmentEntity> Find(Expression<Func<DepartmentEntity, bool>> predicate)
    {
        return Context.Set<DepartmentEntity>().Where(predicate);
    }

    public DepartmentEntity? Get(Guid id)
    {
        return Context.Set<DepartmentEntity>().Find(id);
    }

    public IQueryable<DepartmentEntity> GetAll()
    {
        return Context.Set<DepartmentEntity>().AsQueryable<DepartmentEntity>();
    }

    public void Remove(DepartmentEntity entity)
    {
        Context.Set<DepartmentEntity>().Remove(entity);
    }

    public void RemoveRange(IEnumerable<DepartmentEntity> entities)
    {
        Context.Set<DepartmentEntity>().RemoveRange(entities);
    }
}
