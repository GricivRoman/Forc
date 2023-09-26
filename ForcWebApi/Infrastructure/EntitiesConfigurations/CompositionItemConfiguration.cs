﻿using ForcWebApi.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ForcWebApi.Infrastructure.EntitiesConfigurations
{
    public class CompositionItemConfiguration : IEntityTypeConfiguration<CompositionItem>
    {
        public void Configure(EntityTypeBuilder<CompositionItem> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne<ResourceSpecification>()
                .WithMany(x => x.Composition)
                .HasForeignKey(x => x.ResourceSpecificationId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne<Product>()
                .WithMany(x => x.CompositionItems)
                .HasForeignKey(x => x.ProductId)
                .IsRequired()
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}