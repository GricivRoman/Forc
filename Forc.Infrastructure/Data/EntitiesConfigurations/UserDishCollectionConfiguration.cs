using Forc.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Forc.WebApi.Data.EntitiesConfigurations
{
    public class UserDishCollectionConfiguration : IEntityTypeConfiguration<UserDishCollection>
    {
        public void Configure(EntityTypeBuilder<UserDishCollection> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.User)
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
