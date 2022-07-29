using System.Linq.Expressions;
using AbcBlog.Domain.Interfaces;
using AbcBlog.Domain.SeedWorks;
using AbcBlog.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace AbcBlog.Infrastructure.Repository
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        protected AbcBlogContext _context;
        private readonly DbSet<TEntity> _dbSet;

        public BaseRepository(AbcBlogContext context)
        {
            _context = context;
            _dbSet = _context.Set<TEntity>();
        }

        public virtual void Add(TEntity entity)
        {
            _dbSet.Add(entity);
        }

        public virtual void Update(TEntity entity)
        {
            _dbSet.Update(entity);
        }

        public virtual void Delete(TEntity entity)
        {
            _dbSet.Remove(entity);
        }

        public virtual void Delete(int id)
        {
            _dbSet.Remove(_dbSet.Find(id));
        }

        public virtual List<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate = null)
        {
            return predicate != null ? _dbSet.Where(predicate).ToList() : _dbSet.ToList();
        }

        public virtual TEntity GetById(int id)
        {
            return _dbSet.Find(id);
        }

        public virtual TEntity Get(Expression<Func<TEntity, bool>> predicate)
        {
            return _dbSet.FirstOrDefault(predicate);
        }

        public IQueryable<TEntity> Table => _dbSet.AsQueryable();

        public IUnitOfWork UnitOfWork => _context;

        public virtual async Task AddAsync(TEntity entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public virtual async Task UpdateAsync(TEntity entity)
        {
            _dbSet.Update(entity);
        }

        public virtual async Task DeleteAsync(TEntity entity)
        {
            await Task.Run(() =>
            {
                _dbSet.Remove(entity);
            });
        }

        public virtual async Task DeleteAsync(int id)
        {
            await Task.Run(async () =>
            {
                var entity = await GetByIdAsync(id);
                _dbSet.Remove(entity);
            });

        }

        public virtual async Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> predicate = null)
        {
            return predicate != null ? await _dbSet.Where(predicate).ToListAsync() : await _dbSet.ToListAsync();
        }

        public virtual async Task<TEntity> GetByIdAsync(int id)
        {
            var item = await _dbSet.FindAsync(id);
            return item ?? null!;

            //return await _dbSet.FindAsync(id);
        }

        public virtual async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _dbSet.FirstOrDefaultAsync(predicate);
        }
    }
}
