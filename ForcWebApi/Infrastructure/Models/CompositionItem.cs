using System.ComponentModel.DataAnnotations.Schema;

namespace ForcWebApi.Infrastructure.Entities
{
    /// <summary>
    /// Элемент ресурсной спецификации. Продукт и количество
    /// </summary>
    public class CompositionItem : BaseEntity<Guid>
    {
        /// <summary>
        /// ID ресурсной спецификации
        /// </summary>
        public Guid ResourceSpecificationId { get; set; }

        /// <summary>
        /// Ресурсная спецификация
        /// </summary>
        public ResourceSpecification ResourceSpecification { get; set; }

        /// <summary>
        /// Id используемого продукта
        /// </summary>
        public Guid ProductId { get; set; }

        /// <summary>
        /// Используемый продукт
        /// </summary>
        public Product Product { get; set; }

        /// <summary>
        /// Вес продукта
        /// </summary>
        public double ProductWeightG { get; set; }
    }
}
