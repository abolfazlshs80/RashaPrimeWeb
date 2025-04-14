using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RashaPrimeWeb.Domain.Entities;

namespace RashaPrimeWeb.Infrastructure.Configuration.Entities
{
    public class CategoryToNewsConfiguration : IEntityTypeConfiguration<CategoryToNews>
    {
        public void Configure(EntityTypeBuilder<CategoryToNews> builder)
        {
            builder.HasKey(c => new { c.CategoryId, c.NewsId });


            builder
                .Property<DateTime>("CreateDate")
                .HasDefaultValueSql("GETDATE()");

            builder
                .Property<DateTime>("UpdateDate")
                .HasDefaultValueSql("GETDATE()");
        }
    }



}
