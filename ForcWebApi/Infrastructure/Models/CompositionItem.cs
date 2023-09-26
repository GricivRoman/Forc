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
        public Guid ResourceSpecificationId { get; set; }

        /// <summary>
        /// Используемый продукт
        /// </summary>
        public Guid ProductId { get; set; }

        /// <summary>
        /// Вес продукта
        /// </summary>
        public double ProductWeightG { get; set; }
    }
}
