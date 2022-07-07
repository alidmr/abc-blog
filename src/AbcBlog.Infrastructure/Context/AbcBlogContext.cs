using System.Data;
using AbcBlog.Domain.Aggregates.Articles;
using AbcBlog.Domain.Aggregates.Users;
using AbcBlog.Domain.Interfaces;
using AbcBlog.Domain.SeedWorks;
using AbcBlog.Infrastructure.EntityConfigurations;
using AbcBlog.Infrastructure.Extensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace AbcBlog.Infrastructure.Context
{
    public class AbcBlogContext : DbContext, IUnitOfWork
    {
        public AbcBlogContext(DbContextOptions<AbcBlogContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Article> Articles { get; set; }


        private readonly IMediator _mediator;
        private IDbContextTransaction _currentTransaction;

        public IDbContextTransaction GetCurrentTransaction()
        {
            return _currentTransaction;
        }

        public bool HasActiveTransaction()
        {
            return _currentTransaction != null;
        }

        public AbcBlogContext(DbContextOptions<AbcBlogContext> options, IMediator mediator) : base(options)
        {
            _mediator = mediator;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserEntityTypeConfiguration());
        }

        public async Task<bool> SaveEntitiesAsync(CancellationToken cancellation = default(CancellationToken))
        {
            try
            {
                await _mediator.DispatchDomainEventsAsync(this);

                var result = await base.SaveChangesAsync(cancellation);

                return true;
            }
            catch (Exception exception)
            {
                return false;
            }
        }

        public async Task<IDbContextTransaction> BeginTransactionAsync()
        {
            if (_currentTransaction != null)
            {
                return null;
            }

            _currentTransaction = await Database.BeginTransactionAsync(IsolationLevel.ReadCommitted);

            return _currentTransaction;
        }

        public async Task CommitTransactionAsync(IDbContextTransaction transaction)
        {
            if (transaction == null)
            {
                throw new ArgumentNullException(nameof(transaction));
            }

            if (transaction != _currentTransaction)
            {
                throw new InvalidOperationException(
                    $"Transaction {transaction.TransactionId} is not current transaction");
            }

            try
            {
                await base.SaveChangesAsync();
                await transaction.CommitAsync();
            }
            catch (Exception exception)
            {
                RollbackTransaction();
                throw;
            }
            finally
            {
                if (_currentTransaction != null)
                {
                    _currentTransaction.Dispose();
                    _currentTransaction = null;
                }
            }
        }

        public void RollbackTransaction()
        {
            try
            {
                _currentTransaction?.Rollback();
            }
            finally
            {
                if (_currentTransaction != null)
                {
                    _currentTransaction.Dispose();
                    _currentTransaction = null;
                }
            }
        }
    }
}
