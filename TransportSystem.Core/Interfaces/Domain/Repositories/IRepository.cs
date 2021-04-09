using System.Linq;
using System.Linq.Expressions;
using System.Collections.Generic;
using System;
using System.Threading.Tasks;
using TransportSystem.Core.Entities;

namespace TransportSystem.Core.Interfaces.Domain.Repositories
{
   public interface IRepository<T> where T: BaseEntity
    {
        Task<T> GetAsync(Guid id);

        Task<IEnumerable<T>> GetAsync(IList<Guid> ids);

        Task<bool> ExistsAsync(Guid id);

        Task<bool> ExistsAsync(Expression<Func<T, bool>> expression);

        IQueryable<T> Query();

        Task<T> AddAsync(T entity);

        Task<IEnumerable<T>> AddAsync(IEnumerable<T> entities);

        Task<T> UpdateAsync(T entity);

        Task DeleteAsync(Guid id);

        Task DeleteAsync(T entity);

        IQueryable<T> Query(Expression<Func<T, bool>> expression);

        Task<int> SaveChangesAsync();


        //for generic types
        Task<TEntity> GetAsync<TEntity>(Guid id) where TEntity : BaseEntity;
        Task<TEntity> UpdateAsync<TEntity>(TEntity entity) where TEntity : BaseEntity;
        Task DeleteAsync<TEntity>(Guid id) where TEntity : BaseEntity, new();
        Task DeleteAsync<TEntity>(TEntity entity) where TEntity: BaseEntity;
        Task<TEntity> AddAsync<TEntity>(TEntity entity) where TEntity : BaseEntity;
        Task<IEnumerable<TEntity>> GetAsync<TEntity>(IList<Guid> ids) where TEntity : BaseEntity;
        Task<bool> ExistsAsync<TEntity>(Guid id) where TEntity : BaseEntity;
        Task<bool> ExistsAsync<TEntity>(Expression<Func<TEntity, bool>> expression) where TEntity : BaseEntity;
        IQueryable<TEntity> Query<TEntity>() where TEntity : BaseEntity;
        IQueryable<TEntity> Query<TEntity>(Expression<Func<TEntity, bool>> expression) where TEntity : BaseEntity;
    }
}