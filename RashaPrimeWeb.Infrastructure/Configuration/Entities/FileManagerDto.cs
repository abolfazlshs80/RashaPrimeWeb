using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace RashaPrimeWeb.Infrastructure.Configuration.Entities
{
    public class FileManagerConfiguration : IEntityTypeConfiguration<FileManager>
    {
        public void Configure(EntityTypeBuilder<FileManager> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasMany(a => a.FileToBlog)
                .WithOne(a => a.FileManager)
                .HasForeignKey(a => a.ImageId);
            builder.HasKey(x => x.Id);
            builder.HasMany(a => a.FileToNews)
                .WithOne(a => a.FileManager)
                .HasForeignKey(a => a.ImageId);
            builder.HasMany(a => a.FileToService)
                .WithOne(a => a.FileManager)
                .HasForeignKey(a => a.ImageId);


            builder
                .Property<DateTime>("CreateDate")
                .HasDefaultValueSql("GETDATE()");

            builder
                .Property<DateTime>("UpdateDate")
                .HasDefaultValueSql("GETDATE()");
        }
    }



}
