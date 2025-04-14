using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace RashaPrimeWeb.Infrastructure.Configuration.Entities
{
    public class FileToBlogConfiguration : IEntityTypeConfiguration<FileToBlog>
    {
        public void Configure(EntityTypeBuilder<FileToBlog> builder)
        {
            builder.HasKey(c => new { c.BlogId, c.ImageId });

            builder
                .Property<DateTime>("CreateDate")
                .HasDefaultValueSql("GETDATE()");

            builder
                .Property<DateTime>("UpdateDate")
                .HasDefaultValueSql("GETDATE()");
        }
    }



}
