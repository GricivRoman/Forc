using ForcWebApi.Infrastructure.Entities;
using ForcWebApi.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ForcWebApi.Infrastructure.EntitiesConfigurations
{
    public class UserDishCollectionConfiguration : IEntityTypeConfiguration<UserDishCollection>
    {
        public void Configure(EntityTypeBuilder<UserDishCollection> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne<User>()
                .WithOne(x => x.UserDishCollection)
                .HasForeignKey<User>(x => x.UserDishCollectionId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(x => x.Dishes)
                .WithMany(x => x.UserDishCollections)
                .UsingEntity(
                    i => i.HasOne(typeof(UserDishCollection)).WithMany().HasForeignKey("UserDishCollectionId"),
                    j => j.HasOne(typeof(Dish)).WithMany().HasForeignKey("DishId"));
        }
    }
}
