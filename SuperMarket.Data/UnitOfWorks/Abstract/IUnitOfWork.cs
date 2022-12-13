using SuperMarket.Core.Entities.Abstract;
using SuperMarket.Data.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarket.Data.UnitOfWorks.Abstract
{
    public interface IUnitOfWork : IAsyncDisposable
    {
        IRepository<T> GetRepository<T>() where T : class, IEntity, new();
        Task<int> SaveAsync();
        int Save();
    }
}
