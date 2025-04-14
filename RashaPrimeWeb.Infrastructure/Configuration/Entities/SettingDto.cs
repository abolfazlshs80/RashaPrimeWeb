using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace RashaPrimeWeb.Infrastructure.Configuration.Entities
{
   public class SettingConfiguration : IEntityTypeConfiguration<Setting>
{
   public void Configure(EntityTypeBuilder<Setting> builder)
{
 builder.HasKey(x => x.Id);
}
}
}



}
