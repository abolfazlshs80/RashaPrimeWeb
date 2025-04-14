using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace RashaPrimeWeb.Infrastructure.Configuration.Entities
{
    public class TagToServiceConfiguration : IEntityTypeConfiguration<TagToService>
    {
        public void Configure(EntityTypeBuilder<TagToService> builder)
        {



            builder.HasKey(c => new { c.ServiceId, c.TagId });

            builder
                .Property<DateTime>("CreateDate")
                .HasDefaultValueSql("GETDATE()");

            builder
                .Property<DateTime>("UpdateDate")
                .HasDefaultValueSql("GETDATE()");
        }
    }



}
