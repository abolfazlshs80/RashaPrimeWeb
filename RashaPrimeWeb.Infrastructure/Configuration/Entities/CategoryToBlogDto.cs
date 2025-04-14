using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace RashaPrimeWeb.Infrastructure.Configuration.Entities
{
    public class CategoryToBlogConfiguration : IEntityTypeConfiguration<CategoryToBlog>
    {
        public void Configure(EntityTypeBuilder<CategoryToBlog> builder)
        {
            builder.HasKey(c => new { c.CategoryId, c.BlogId });


            builder
                .Property<DateTime>("CreateDate")
                .HasDefaultValueSql("GETDATE()");

            builder
                .Property<DateTime>("UpdateDate")
                .HasDefaultValueSql("GETDATE()");
        }
    }



}
