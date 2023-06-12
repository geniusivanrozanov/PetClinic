using PetClinic.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using PetClinic.DAL.Interfaces.Entities;

namespace PetClinic.DAL.Interfaces.Repositories
{
    public interface IRepository
    {
        TEntity? Get<TEntity>(Guid id)  where TEntity : class, IEntity<Guid>;
        IQueryable<TEntity> GetAll<TEntity>()  where TEntity : class, IEntity<Guid>;
        IQueryable<TEntity> Find<TEntity>(Expression<Func<TEntity, bool>> predicate)  where TEntity : class, IEntity<Guid>;

        void Add<TEntity>(TEntity entity)  where TEntity : class, IEntity<Guid>;
        void AddRange<TEntity>(IEnumerable<TEntity> entities)  where TEntity : class, IEntity<Guid>;
        void Remove<TEntity>(TEntity entity)  where TEntity : class, IEntity<Guid>;
        void RemoveRange<TEntity>(IEnumerable<TEntity> entities)  where TEntity : class, IEntity<Guid>;

    }
}
