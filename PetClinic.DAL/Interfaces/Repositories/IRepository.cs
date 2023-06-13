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
    public interface IRepository<TEntity, TId> where TEntity : IEntity<TId>
    {
        TEntity? Get(TId id);
        IQueryable<TEntity> GetAll();
        IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);

        void Add(TEntity entity);
        void AddRange(IEnumerable<TEntity> entities);
        void Remove(TEntity entity);
        void RemoveRange(IEnumerable<TEntity> entities);
        void Update(TEntity entity);
    }
}
