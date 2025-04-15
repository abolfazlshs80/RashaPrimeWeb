using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RashaPrimeWeb.Domain.Entities;

namespace RashaPrimeWeb.Domain.Interface
{
    public interface IUnitOfWork : IDisposable
    {

        ICategoryRepository CategoryRepository { get; }
        IRepository<Category> GenericCategoryRepository { get; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
