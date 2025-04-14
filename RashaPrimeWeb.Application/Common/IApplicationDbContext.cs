using Microsoft.EntityFrameworkCore;

namespace RashaPrimeWeb.Application.Common;

public interface IApplicationDbContext
{
    DbSet<Domain.Entities.Category> Category { get; }

    int SaveChanges();
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
