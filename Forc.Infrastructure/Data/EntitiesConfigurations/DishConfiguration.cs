using Microsoft.EntityFrameworkCore;
using Forc.Infrastructure.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Forc.WebApi.Data.EntitiesConfigurations
{
    public class DishConfiguration : IEntityTypeConfiguration<Dish>
    {
        public void Configure(EntityTypeBuilder<Dish> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.ResourseSpecification)
                .WithOne(x => x.Dish)
                .HasForeignKey<Dish>(x => x.ResourceSpecificationId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(x => x.UserDishCollections)
                .WithMany(x => x.Dishes)
                .UsingEntity(
                    i => i.HasOne(typeof(UserDishCollection)).WithMany().HasForeignKey("UserDishCollectionId"),
                    j => j.HasOne(typeof(Dish)).WithMany().HasForeignKey("DishId"));

            builder.HasMany(x => x.Categoties)
                .WithMany(x => x.Dishes)
                .UsingEntity(
                    i => i.HasOne(typeof(DishCategory)).WithMany().HasForeignKey("DishCategoryId"),
                    j => j.HasOne(typeof(Dish)).WithMany().HasForeignKey("DishId"));
        }
    }
}
