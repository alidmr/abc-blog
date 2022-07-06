using AbcBlog.Domain.SeedWorks;

namespace AbcBlog.Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        //IBaseRepository<TEntity> GetRepository<TEntity>() where TEntity : BaseEntity;

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken));
        Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default(CancellationToken));
    }
}
