using ForcWebApi.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ForcWebApi.Infrastructure.EntitiesConfigurations
{
    public class PhysicalActivityCatalogConfiguration : IEntityTypeConfiguration<PhysicalActivityCatalog>
    {
        public void Configure(EntityTypeBuilder<PhysicalActivityCatalog> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasMany<User>()
                .WithOne(x => x.PhysicalActivity)
                .HasForeignKey(x => x.PhysicalActivityId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
