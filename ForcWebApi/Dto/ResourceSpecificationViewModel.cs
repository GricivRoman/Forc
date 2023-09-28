namespace Forc.WebApi.Dto
{
    /// <summary>
    /// Ресурсная спецификация блюда - список ингридиентов с количеством
    /// </summary>
    public class ResourceSpecificationViewModel
    {
        public Guid? Id { get; set; }

        /// <summary>
        /// Блюдо
        /// </summary>
        public Guid DishId { get; set; }

        /// <summary>
        /// Набор ингридиентов с количеством
        /// </summary>
        public ICollection<CompositionItemViewModel> Composition { get; set; }

        /// <summary>
        /// Итоговый вес готового блюда
        /// </summary>
        public double OutputDishWeightG { get; set; }

        /// <summary>
        /// ID энергетическая ценность блюда по текущей ресурсной спецификации
        /// </summary>
        public Guid SpecNutritionValueId { get; set; }

        /// <summary>
        /// Энергетическая ценность блюда по текущей ресурсной спецификации
        /// </summary>
        public SpecNutritionValueViewModel SpecNutritionValue { get; set; }
    }
}
