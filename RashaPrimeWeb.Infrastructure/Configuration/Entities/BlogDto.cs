using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RashaPrimeWeb.Domain.Entities;

namespace RashaPrimeWeb.Infrastructure.Configuration.Entities
{
    public class BlogConfiguration : IEntityTypeConfiguration<Blog>
    {
        public void Configure(EntityTypeBuilder<Blog> builder)
        {
            builder.HasKey(x => x.Id);

            builder
                .Property<DateTime>("CreateDate")
                .HasDefaultValueSql("GETDATE()");
           
            builder
                .Property<DateTime>("UpdateDate")
                .HasDefaultValueSql("GETDATE()");
        }
    }



}
