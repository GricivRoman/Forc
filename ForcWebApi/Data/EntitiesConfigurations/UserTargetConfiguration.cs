﻿using Forc.WebApi.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Forc.WebApi.Data.EntitiesConfigurations
{
    public class UserTargetConfiguration : IEntityTypeConfiguration<UserTarget>
    {
        public void Configure(EntityTypeBuilder<UserTarget> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.User)
                .WithMany(x => x.Targets)
                .HasForeignKey(x => x.UserId)
                .IsRequired()
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.DailyRate)
                .WithOne(x => x.UserTarget)
                .HasForeignKey<UserTarget>(x => x.DailyRateId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
