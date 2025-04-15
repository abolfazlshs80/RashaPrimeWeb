using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RashaPrimeWeb.Domain.Entities;

namespace RashaPrimeWeb.Infrastructure.Configuration.Entities
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(a => a.IsMenuHomePage).HasDefaultValue(false);
            builder.Property(a => a.IsSugestionHomePage).HasDefaultValue(false);
            builder.Property(a => a.IsDeleted).HasDefaultValue(false);
            builder.Property(a => a.Status).HasDefaultValue(true);
            builder
                .Property<DateTime>("CreateDate")
                .HasDefaultValueSql("GETDATE()");

            builder
                .Property<DateTime>("UpdateDate")
                .HasDefaultValueSql("GETDATE()");
        }
    }



}
