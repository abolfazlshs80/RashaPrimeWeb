using Microsoft.EntityFrameworkCore;

using RashaPrimeWeb.Domain.Entities.Common;

namespace RashaPrimeWeb.DataLayer.Context
{
    public abstract class AuditableDbContext(DbContextOptions options) : DbContext(options)
    {
        public override int SaveChanges()
        {

            UpdateShadowProperties();

            return base.SaveChanges();
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {

            UpdateShadowProperties();
            return base.SaveChangesAsync(cancellationToken);

        }

        private void UpdateShadowProperties()
        {
            foreach (var entry in ChangeTracker.Entries().Where(e => e.State == EntityState.Modified))
            {
                entry.Property("UpdateDate").CurrentValue = DateTime.Now;
            }
        }

    }
}
