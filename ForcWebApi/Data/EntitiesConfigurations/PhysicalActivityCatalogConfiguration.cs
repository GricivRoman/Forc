using Forc.WebApi.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Forc.WebApi.Data.EntitiesConfigurations
{
    public class PhysicalActivityCatalogConfiguration : IEntityTypeConfiguration<PhysicalActivity>
    {
        public void Configure(EntityTypeBuilder<PhysicalActivity> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasMany(x => x.Users)
                .WithOne(x => x.PhysicalActivity)
                .HasForeignKey(x => x.PhysicalActivityId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
