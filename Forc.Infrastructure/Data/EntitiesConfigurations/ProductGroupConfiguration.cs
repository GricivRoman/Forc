using Forc.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Forc.WebApi.Data.EntitiesConfigurations
{
    public class ProductGroupConfiguration : IEntityTypeConfiguration<ProductGroup>
    {
        public void Configure(EntityTypeBuilder<ProductGroup> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasMany(x => x.Products)
                .WithOne(x => x.ProductGroup)
                .HasForeignKey(x => x.ProductGroupId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
