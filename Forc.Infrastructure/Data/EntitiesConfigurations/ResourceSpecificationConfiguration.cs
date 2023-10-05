using Forc.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Forc.WebApi.Data.EntitiesConfigurations
{
    public class ResourceSpecificationConfiguration : IEntityTypeConfiguration<ResourceSpecification>
    {
        public void Configure(EntityTypeBuilder<ResourceSpecification> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.Dish)
                .WithOne(x => x.ResourseSpecification)
                .HasForeignKey<ResourceSpecification>(x => x.DishId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(x => x.Composition)
                .WithOne(x => x.ResourceSpecification)
                .HasForeignKey(x => x.ResourceSpecificationId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.SpecNutritionValue)
                .WithOne(x => x.ResourceSpecification)
                .HasForeignKey<ResourceSpecification>(x => x.SpecNutritionValueId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
