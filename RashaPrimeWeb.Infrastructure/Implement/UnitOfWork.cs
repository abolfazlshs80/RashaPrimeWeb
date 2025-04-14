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
        ) : IUnitOfWork
    {
        private readonly Dictionary<Type, object> _repositories;


        public ICategoryRepository CategoryRepository => _categoryRepository;


        public IRepository<T> Repository<T>() where T : class
        {
            if (_repositories.ContainsKey(typeof(T)))
            {
                return (IRepository<T>)_repositories[typeof(T)];
            }

            var repository = new GenericRepository<T>(context);
            _repositories.Add(typeof(T), repository);
            return repository;
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
