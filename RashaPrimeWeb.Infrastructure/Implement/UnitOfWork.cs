using Microsoft.EntityFrameworkCore;
using RashaPrimeWeb.Domain.Interface;
using RashaPrimeWeb.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RashaPrimeWeb.Infrastructure.Implement
{
    public class UnitOfWork(ApplicationDbContext context
        ,ICategoryRepository _categoryRepository
        , IRepository<Category> _genericCategoryRepository
        ) : IUnitOfWork
    {
     


        public ICategoryRepository CategoryRepository => _categoryRepository;
        public IRepository<Category> GenericCategoryRepository => _genericCategoryRepository;






        public IRepository<T> Repository<T>() where T : class
        {
            throw new NotImplementedException();
        }

        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return await context.SaveChangesAsync(cancellationToken);
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}
