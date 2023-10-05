using Forc.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Forc.WebApi.Data.EntitiesConfigurations
{
    public class PhysicalActivityCatalogConfiguration : IEntityTypeConfiguration<PhysicalActivity>
    {
        public void Configure(EntityTypeBuilder<PhysicalActivity> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasMany(x => x.Users)
                .WithOne(x => x.PhysicalActivity)
                .HasForeignKey(x => x.PhysicalActivityId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasData(GetDataToSeed());
        }

        private PhysicalActivity[] GetDataToSeed()
        {
            // TODO уточнить набор данных, когда буду делать калькулятор нормы для пользователя
            PhysicalActivity[] dataList = 
            {
                new PhysicalActivity() { Id = new Guid("4AE56DC2-4F4D-4CB2-A90D-898EC1AAE801"), Name = "Low", Description = "Low physical activity", PhysicalActivityMultiplier = 1 },
                new PhysicalActivity() { Id = new Guid("90877285-0C4A-4F19-8C2A-955B12AAF58F"), Name = "Medium", Description = "Medium physical activity", PhysicalActivityMultiplier = 1.25 },
                new PhysicalActivity() { Id = new Guid("B6433404-B898-4AB2-AB85-DC41D09361A4"), Name = "Height", Description = "Height physical activity", PhysicalActivityMultiplier = 1.5 }
            };

            return dataList.ToArray();
        }
    }
}
