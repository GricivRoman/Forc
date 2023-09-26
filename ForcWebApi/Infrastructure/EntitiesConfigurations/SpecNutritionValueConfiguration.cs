using ForcWebApi.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ForcWebApi.Infrastructure.EntitiesConfigurations
{
    public class SpecNutritionValueConfiguration : IEntityTypeConfiguration<SpecNutritionValue>
    {
        public void Configure(EntityTypeBuilder<SpecNutritionValue> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne<ResourceSpecification>()
                .WithOne(x => x.SpecNutritionValue)
                .HasForeignKey<SpecNutritionValue>(x => x.ResourceSpecificationId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
