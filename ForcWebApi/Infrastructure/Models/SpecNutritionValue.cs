using System.ComponentModel.DataAnnotations.Schema;

namespace ForcWebApi.Infrastructure.Entities
{
    /// <summary>
    /// Энергитическая ценность блюда на 100 грамм
    /// </summary>
    public class SpecNutritionValue : BaseFoodEntity<Guid>
    {
        /// <summary>
        /// ID ресурсной спецификации
        /// </summary>
        public Guid ResourceSpecificationId { get; set; }

        /// <summary>
        /// Ресурсная спецификация
        /// </summary>
        public ResourceSpecification ResourceSpecification { get; set; }
    }
}
