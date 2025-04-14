using RashaPrimeWeb.Domain.Entities;

namespace RashaPrimeWeb.Domain.Interface;
// در لایه Domain/Interfaces
public interface ICategoryRepository
{
    Task<Category> GetByIdAsync(int id, CancellationToken cancellationToken = default);
    Task<IEnumerable<Category>> GetAllAsync(CancellationToken cancellationToken = default);
    Task AddAsync(Category entity, CancellationToken cancellationToken = default);
    Task UpdateAsync(Category entity, CancellationToken cancellationToken = default);
    Task DeleteAsync(int id, CancellationToken cancellationToken = default);

    // متد اختصاصی برای Queryهای پیچیده
    Task<IEnumerable<Category>> GetCategoryReportsAsync(CancellationToken cancellationToken = default);
}
