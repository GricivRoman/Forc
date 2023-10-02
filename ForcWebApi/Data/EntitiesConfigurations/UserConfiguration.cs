using Forc.WebApi.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Forc.WebApi.Data.EntitiesConfigurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.PhysicalActivity)
                .WithMany(x => x.Users)
                .HasForeignKey(x => x.PhysicalActivityId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(x => x.WeightConditions)
                .WithOne(x => x.User)
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(x => x.Targets)
                .WithOne(x => x.User)
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(x => x.Meals)
                .WithOne(x => x.User)
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.UserDishCollection)
                .WithOne(x => x.User)
                .HasForeignKey<User>(x => x.UserDishCollectionId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
