using ForcWebApi.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ForcWebApi.Infrastructure.EntitiesConfigurations
{
    public class UserTargetConfiguration : IEntityTypeConfiguration<UserTarget>
    {
        public void Configure(EntityTypeBuilder<UserTarget> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne<User>()
                .WithMany(x => x.Targets)
                .HasForeignKey(x => x.UserId)
                .IsRequired()
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne<DailyRate>()
                .WithOne()
                .HasForeignKey<UserTarget>(x => x.DailyRateId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
