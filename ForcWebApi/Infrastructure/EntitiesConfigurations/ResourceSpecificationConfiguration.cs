using ForcWebApi.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ForcWebApi.Infrastructure.EntitiesConfigurations
{
    public class ResourceSpecificationConfiguration : IEntityTypeConfiguration<ResourceSpecification>
    {
        public void Configure(EntityTypeBuilder<ResourceSpecification> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne<Dish>()
                .WithOne(x => x.ResourseSpecification)
                .HasForeignKey<ResourceSpecification>(x => x.DishId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany<CompositionItem>()
                .WithOne(x => x.ResourceSpecification)
                .HasForeignKey(x => x.ResourceSpecificationId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne<SpecNutritionValue>()
                .WithOne(x => x.ResourceSpecification)
                .HasForeignKey<ResourceSpecification>(x => x.SpecNutritionValueId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
