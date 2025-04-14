using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace RashaPrimeWeb.Infrastructure.Configuration.Entities
{
    public class FileToServiceConfiguration : IEntityTypeConfiguration<FileToService>
    {
        public void Configure(EntityTypeBuilder<FileToService> builder)
        {
            builder.HasKey(c => new { c.ServiceId, c.ImageId });

            builder
                .Property<DateTime>("CreateDate")
                .HasDefaultValueSql("GETDATE()");

            builder
                .Property<DateTime>("UpdateDate")
                .HasDefaultValueSql("GETDATE()");
        }
    }



}
