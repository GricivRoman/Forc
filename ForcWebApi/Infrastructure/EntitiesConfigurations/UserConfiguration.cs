using ForcWebApi.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ForcWebApi.Infrastructure.EntitiesConfigurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne<PhysicalActivityCatalog>()
                .WithMany(x => x.Users)
                .HasForeignKey(x => x.PhysicalActivityId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasMany<WeightCondition>()
                .WithOne(x => x.User)
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany<UserTarget>()
                .WithOne(x => x.User)
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany<Meal>()
                .WithOne(x => x.User)
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne<UserDishCollection>()
                .WithOne(x => x.User)
                .HasForeignKey<User>(x => x.UserDishCollectionId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
