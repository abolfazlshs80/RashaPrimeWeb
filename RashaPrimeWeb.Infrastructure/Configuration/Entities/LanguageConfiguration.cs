using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace RashaPrimeWeb.Infrastructure.Configuration.Entities
{
    public class LanguageConfiguration : IEntityTypeConfiguration<Language>
    {
        public void Configure(EntityTypeBuilder<Language> builder)
        {
            builder.HasKey(x => x.Lang_Id);

            builder.HasMany(a => a.Blog)
                .WithOne(a => a.Language)
                .HasForeignKey(a => a.Lang_Id);

            builder.HasMany(a => a.Menu)
                .WithOne(a => a.Language)
                .HasForeignKey(a => a.Lang_Id);

            builder.HasMany(a => a.Slider)
                .WithOne(a => a.Language)
                .HasForeignKey(a => a.Lang_Id);

            builder.HasMany(a => a.Tag)
                .WithOne(a => a.Language)
                .HasForeignKey(a => a.Lang_Id);

            builder.HasMany(a => a.Setting)
                .WithOne(a => a.Language)
                .HasForeignKey(a => a.Lang_Id);

            builder.HasMany(a => a.Service)
                .WithOne(a => a.Language)
                .HasForeignKey(a => a.Lang_Id);

            builder.HasMany(a => a.News)
                .WithOne(a => a.Language)
                .HasForeignKey(a => a.Lang_Id);

            builder.HasMany(a => a.Faq)
                .WithOne(a => a.Language)
                .HasForeignKey(a => a.Lang_Id);

            builder.HasMany(a => a.Category)
                .WithOne(a => a.Language)
                .HasForeignKey(a => a.Lang_Id);


            builder
                .Property<DateTime>("CreateDate")
                .HasDefaultValueSql("GETDATE()");

            builder
                .Property<DateTime>("UpdateDate")
                .HasDefaultValueSql("GETDATE()");
        }
    }



}
