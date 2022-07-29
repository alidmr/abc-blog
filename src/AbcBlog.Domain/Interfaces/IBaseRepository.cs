using System.Linq.Expressions;
using AbcBlog.Domain.SeedWorks;

namespace AbcBlog.Domain.Interfaces
{
    public interface IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        #region Sync Methods
        void Add(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
        void Delete(int id);
        List<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate = null);
        TEntity GetById(int id);
        TEntity Get(Expression<Func<TEntity, bool>> predicate); 
        #endregion

        IQueryable<TEntity> Table { get; }

        IUnitOfWork UnitOfWork { get; }


        #region Async Methods
        Task AddAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
        Task DeleteAsync(TEntity entity);
        Task DeleteAsync(int id);
        Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> predicate = null);
        Task<TEntity> GetByIdAsync(int id);
        Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate); 
        #endregion
    }
}
