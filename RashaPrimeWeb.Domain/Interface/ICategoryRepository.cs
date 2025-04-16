using RashaPrimeWeb.Application.Common.Models;
using RashaPrimeWeb.Domain.Entities;

namespace RashaPrimeWeb.Domain.Interface;
// در لایه Domain/Interfaces
public interface ICategoryRepository
{
    Task<Category> GetByIdAsync(int id, CancellationToken cancellationToken = default);
    Task<PaginatedResult<Domain.Entities.Category>> GetAllAsync(string Title, bool GetOldest, int PageNumber, int PageSize, CancellationToken cancellationToken = default);
    Task AddAsync(Category entity, CancellationToken cancellationToken = default);
    Task UpdateAsync(Category entity, CancellationToken cancellationToken = default);
    Task DeleteAsync(int id, CancellationToken cancellationToken = default);

    // متد اختصاصی برای Queryهای پیچیده
    Task<IEnumerable<Category>> GetCategoryReportsAsync(CancellationToken cancellationToken = default);
}
