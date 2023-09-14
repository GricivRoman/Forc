using System.ComponentModel.DataAnnotations.Schema;

namespace ForcWebApi.Infrastructure.Entities
{
    /// <summary>
    /// Ресурсная спецификация блюда - список ингридиентов с количеством
    /// </summary>
    public class ResourseSpecification : BaseEntity<Guid>
    {
        /// <summary>
        /// Блюдо
        /// </summary>
        [ForeignKey(nameof(Dish))]
        public Guid DishId { get; set; }

        /// <summary>
        /// Набор ингридиентов с количеством
        /// </summary>
        public ICollection<CompositionItem> Composition { get; set; }

        /// <summary>
        /// Итоговый вес готового блюда
        /// </summary>
        public double OutputDishWeightG { get; set; }

        /// <summary>
        /// ID энергетическая ценность блюда по текущей ресурсной спецификации
        /// </summary>
        [ForeignKey(nameof(SpecNutritionValue))]
        public Guid SpecNutritionValueId { get; set; }

        /// <summary>
        /// Энергетическая ценность блюда по текущей ресурсной спецификации
        /// </summary>
        public SpecNutritionValue SpecNutritionValue { get; set; }
    }
}
