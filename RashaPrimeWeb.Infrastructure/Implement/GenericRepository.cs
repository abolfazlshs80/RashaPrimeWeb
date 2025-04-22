using Microsoft.EntityFrameworkCore;
using RashaPrimeWeb.Domain.Interface;
using RashaPrimeWeb.Infrastructure.Context;
using System.Linq.Expressions;

namespace RashaPrimeWeb.Infrastructure.Implement
{

    public class GenericRepository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<T> _dbSet;

        public GenericRepository(ApplicationDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public async Task<T> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            return await _dbSet.FindAsync(new object[] { id }, cancellationToken);
        }
        public IQueryable<T> GetAllWithIncludes(
            Func<IQueryable<T>, IQueryable<T>> includeFunc = null,
            Expression<Func<T, bool>> filter = null)
        {
            // شروع کوئری با DbSet
            IQueryable<T> query = _dbSet;

            // اعمال شرط‌ها (اگر وجود داشته باشند)
            if (filter != null)
            {
                query = query.Where(filter);
            }

            // اعمال Includes (اگر وجود داشته باشند)
            if (includeFunc != null)
            {
                query = includeFunc(query);
            }

            return query;
        }
        public async Task<IQueryable<T>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return  _dbSet.AsQueryable();
        }

        public async Task<T> AddAsync(T entity, CancellationToken cancellationToken = default)
        {
            await _dbSet.AddAsync(entity, cancellationToken);
            return entity;
            //     await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task UpdateAsync(T entity, CancellationToken cancellationToken = default)
        {
            _dbSet.Update(entity);
       //     await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task DeleteAsync(int id, CancellationToken cancellationToken = default)
        {
            var entity = await GetByIdAsync(id, cancellationToken);
            if (entity != null)
            {
                _dbSet.Remove(entity);
           //     await _context.SaveChangesAsync(cancellationToken);
            }
        }
    }
}
