using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace RashaPrimeWeb.Infrastructure.Configuration.Entities
{
    public class FileToNewsConfiguration : IEntityTypeConfiguration<FileToNews>
    {
        public void Configure(EntityTypeBuilder<FileToNews> builder)
        {


            builder.HasKey(c => new { c.NewsId, c.ImageId });


            builder
                .Property<DateTime>("CreateDate")
                .HasDefaultValueSql("GETDATE()");

            builder
                .Property<DateTime>("UpdateDate")
                .HasDefaultValueSql("GETDATE()");
        }
    }



}
