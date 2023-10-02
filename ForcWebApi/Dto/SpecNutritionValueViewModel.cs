namespace Forc.WebApi.Dto
{
    /// <summary>
    /// Энергитическая ценность блюда на 100 грамм
    /// </summary>
    public class SpecNutritionValueViewModel
    {
        public Guid? Id { get; set; }

        /// <summary>
        /// ID ресурсной спецификации
        /// </summary>
        public Guid ResourceSpecificationId { get; set; }

        /// <summary>
        /// Ресурсная спецификация
        /// </summary>
        public ResourceSpecificationViewModel ResourceSpecification { get; set; }

        /// <summary>
        /// Калорийность
        /// </summary>
        public double Calories { get; set; }

        /// <summary>
        /// Углеводы
        /// </summary>
        public double Carbohydrate { get; set; }

        /// <summary>
        /// Жиры
        /// </summary>
        public double Fat { get; set; }

        /// <summary>
        /// Белки
        /// </summary>
        public double Protein { get; set; }
    }
}
