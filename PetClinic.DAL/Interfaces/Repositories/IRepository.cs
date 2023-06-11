using PetClinic.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PetClinic.DAL.Interfaces.Repositories
{
    public interface IRepository
    {
        TEntity? Get<TEntity>(Guid id) where TEntity : BaseEntity;
        IQueryable<TEntity> GetAll<TEntity>() where TEntity : BaseEntity;
        IQueryable<TEntity> Find<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : BaseEntity;

        void Add<TEntity>(TEntity entity) where TEntity : BaseEntity;
        void AddRange<TEntity>(IEnumerable<TEntity> entities) where TEntity : BaseEntity;
        void Remove<TEntity>(TEntity entity) where TEntity : BaseEntity;
        void RemoveRange<TEntity>(IEnumerable<TEntity> entities) where TEntity : BaseEntity;

    }
}
