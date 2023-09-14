using System.ComponentModel.DataAnnotations.Schema;

namespace ForcWebApi.Infrastructure.Entities
{
    /// <summary>
    /// Энергитическая ценность блюда на 100 грамм
    /// </summary>
    public class SpecNutritionValue : BaseFoodEntity<Guid>
    {
        /// <summary>
        /// Ресурсная спецификация
        /// </summary>
        [ForeignKey(nameof(ResourseSpecification))]
        public Guid ResourseSpecificationId { get; set; }
    }
}
