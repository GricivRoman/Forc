﻿using ForcWebApi.Infrastructure.Entities;
using ForcWebApi.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ForcWebApi.Infrastructure.EntitiesConfigurations
{
    public class DishCategoryConfiguration : IEntityTypeConfiguration<DishCategory>
    {
        public void Configure(EntityTypeBuilder<DishCategory> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasMany(x => x.Dishes)
                .WithMany(x => x.Categoties)
                .UsingEntity(
                    i => i.HasOne(typeof(DishCategory)).WithMany().HasForeignKey("DishCategoryId"),
                    j => j.HasOne(typeof(Dish)).WithMany().HasForeignKey("DishId"));
        }
    }
}
