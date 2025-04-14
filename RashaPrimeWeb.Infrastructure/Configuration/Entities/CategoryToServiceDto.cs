using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RashaPrimeWeb.Domain.Entities;

namespace RashaPrimeWeb.Infrastructure.Configuration.Entities
{
    public class CategoryToServiceConfiguration : IEntityTypeConfiguration<CategoryToService>
    {
        public void Configure(EntityTypeBuilder<CategoryToService> builder)
        {
            builder.HasKey(c => new { c.CategoryId, c.ServiceId });


            builder
                .Property<DateTime>("CreateDate")
                .HasDefaultValueSql("GETDATE()");

            builder
                .Property<DateTime>("UpdateDate")
                .HasDefaultValueSql("GETDATE()");
        }
    }



}
