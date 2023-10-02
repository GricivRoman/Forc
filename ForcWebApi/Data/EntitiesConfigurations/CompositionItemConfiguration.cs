using Forc.WebApi.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Forc.WebApi.Data.EntitiesConfigurations
{
    public class CompositionItemConfiguration : IEntityTypeConfiguration<CompositionItem>
    {
        public void Configure(EntityTypeBuilder<CompositionItem> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.ResourceSpecification)
                .WithMany(x => x.Composition)
                .HasForeignKey(x => x.ResourceSpecificationId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Product)
                .WithMany(x => x.CompositionItems)
                .HasForeignKey(x => x.ProductId)
                .IsRequired()
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
