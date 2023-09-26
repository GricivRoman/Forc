using ForcWebApi.Infrastructure.Entities;
using ForcWebApi.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ForcWebApi.Infrastructure.EntitiesConfigurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasMany<CompositionItem>()
                .WithOne(x => x.Product)
                .HasForeignKey(x => x.ProductId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne<ProductGroup>()
                .WithMany(x => x.Products)
                .HasForeignKey(x => x.ProductGroupId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
