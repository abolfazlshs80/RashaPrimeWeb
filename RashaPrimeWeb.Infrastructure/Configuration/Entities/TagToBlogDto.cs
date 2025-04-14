using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace RashaPrimeWeb.Infrastructure.Configuration.Entities
{
    public class TagToBlogConfiguration : IEntityTypeConfiguration<TagToBlog>
    {
        public void Configure(EntityTypeBuilder<TagToBlog> builder)
        {
            builder.HasKey(c => new { c.BlogId, c.TagId });

            builder
                .Property<DateTime>("CreateDate")
                .HasDefaultValueSql("GETDATE()");

            builder
                .Property<DateTime>("UpdateDate")
                .HasDefaultValueSql("GETDATE()");
        }
    }



}
