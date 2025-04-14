using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace RashaPrimeWeb.Infrastructure.Configuration.Entities
{
    public class UsersConfiguration : IEntityTypeConfiguration<UserApplication>
    {
        public void Configure(EntityTypeBuilder<UserApplication> builder)
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
