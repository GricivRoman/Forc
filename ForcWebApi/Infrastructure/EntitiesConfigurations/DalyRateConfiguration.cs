using ForcWebApi.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ForcWebApi.Infrastructure.EntitiesConfigurations
{
    public class DalyRateConfiguration : IEntityTypeConfiguration<DailyRate>
    {
        public void Configure(EntityTypeBuilder<DailyRate> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne<UserTarget>()
                .WithOne(x => x.DailyRate)
                .HasForeignKey<DailyRate>(x => x.UserTargetId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
