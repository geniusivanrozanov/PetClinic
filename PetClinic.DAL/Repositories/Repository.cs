using PetClinic.DAL.Entities;
using PetClinic.DAL.Interfaces.Repositories;
using System.Linq.Expressions;

namespace PetClinic.DAL.Repositories
{
    public class Repository : IRepository
    {

        protected readonly AppDbContext Context;

       public Repository(AppDbContext context)
        {
            Context = context;
        }

        public TEntity? Get<TEntity>(Guid id) where TEntity : BaseEntity
        {

            return Context.Set<TEntity>().Find(id);
        }

        public IQueryable<TEntity> GetAll<TEntity>() where TEntity : BaseEntity
        {

            return Context.Set<TEntity>().AsQueryable<TEntity>();
        }

        public IQueryable<TEntity> Find<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : BaseEntity
        {
            return Context.Set<TEntity>().Where(predicate);
        }

        public void Add<TEntity>(TEntity entity) where TEntity : BaseEntity
        {
            Context.Set<TEntity>().Add(entity);
        }

        public void AddRange<TEntity>(IEnumerable<TEntity> entities) where TEntity : BaseEntity
        {
            Context.Set<TEntity>().AddRange(entities);
        }

        public void Remove<TEntity>(TEntity entity) where TEntity : BaseEntity
        {
            Context.Set<TEntity>().Remove(entity);
        }

        public void RemoveRange<TEntity>(IEnumerable<TEntity> entities) where TEntity : BaseEntity
        {
            Context.Set<TEntity>().RemoveRange(entities);
        }
    }
}
