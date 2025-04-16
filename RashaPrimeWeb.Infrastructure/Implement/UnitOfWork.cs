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
    public class UnitOfWork : IUnitOfWork
    {

        private readonly ApplicationDbContext _context;
        private readonly ICategoryRepository _categoryRepository;
        private readonly Dictionary<Type, object> _repositories;

        public UnitOfWork(ApplicationDbContext context, ICategoryRepository _categoryRepository)
        {
            this._categoryRepository = _categoryRepository;
            this._context = context;
            this._repositories = new Dictionary<Type, object>();
        }

        public ICategoryRepository CategoryRepository => _categoryRepository;
        //public IRepository<Domain.Entities.Category> GenericCategoryRepository => _genericCategoryRepository;






        public IRepository<T> Repository<T>() where T : class
        {
            if (_repositories.ContainsKey(typeof(T)))
            {
                return (IRepository<T>)_repositories[typeof(T)];
            }

            var repository = new GenericRepository<T>(_context);
            _repositories.Add(typeof(T), repository);
            return repository;
        }

        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return await _context.SaveChangesAsync(cancellationToken);
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
