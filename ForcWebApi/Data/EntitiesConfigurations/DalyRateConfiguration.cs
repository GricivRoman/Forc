﻿using Forc.WebApi.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Forc.WebApi.Data.EntitiesConfigurations
{
    public class DalyRateConfiguration : IEntityTypeConfiguration<DailyRate>
    {
        public void Configure(EntityTypeBuilder<DailyRate> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.UserTarget)
                .WithOne(x => x.DailyRate)
                .HasForeignKey<DailyRate>(x => x.UserTargetId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
