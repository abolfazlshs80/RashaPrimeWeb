using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace RashaPrimeWeb.Infrastructure.Configuration.Entities
{
    public class TagToNewsConfiguration : IEntityTypeConfiguration<TagToNews>
    {
        public void Configure(EntityTypeBuilder<TagToNews> builder)
        {
            builder.HasKey(c => new { c.NewsId, c.TagId });

            builder
                .Property<DateTime>("CreateDate")
                .HasDefaultValueSql("GETDATE()");

            builder
                .Property<DateTime>("UpdateDate")
                .HasDefaultValueSql("GETDATE()");
        }
    }



}
