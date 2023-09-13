using System.ComponentModel.DataAnnotations.Schema;

namespace ForcWebApi.Infrastructure.Entities
{
    /// <summary>
    /// Элемент ресурсной спецификации. Продукт и количество
    /// </summary>
    public class CompositionItem : BaseEntity<Guid>
    {
        /// <summary>
        /// Ресурсная спецификация
        /// </summary>
        [ForeignKey(nameof(ResourseSpecification))]
        public Guid ResourseSpecificationId { get; set; }

        /// <summary>
        /// Используемый продукт
        /// </summary>
        [ForeignKey(nameof(Product))]
        public Guid ProductId { get; set; }

        /// <summary>
        /// Вес продукта
        /// </summary>
        public double ProductWeightG { get; set; }
    }
}
