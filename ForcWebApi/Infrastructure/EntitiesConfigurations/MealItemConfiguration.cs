using ForcWebApi.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ForcWebApi.Infrastructure.EntitiesConfigurations
{
    public class MealItemConfiguration : IEntityTypeConfiguration<MealItem>
    {
        public void Configure(EntityTypeBuilder<MealItem> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.Meal)
                .WithMany(x => x.MealItems)
                .HasForeignKey(x => x.MealId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Dish)
                .WithMany(x => x.MealItems)
                .HasForeignKey(x => x.DishId)
                .IsRequired()
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
