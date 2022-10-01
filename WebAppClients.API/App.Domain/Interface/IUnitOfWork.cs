using System;
using System.Threading.Tasks;

namespace App.Domain.Interface
{
    public interface IUnitOfWork : IAsyncDisposable
    {
        IGenericRepository<TEntity> GetRepository<TEntity>() where TEntity : class;
        Task<int> CompleteAsync();
    }
}
