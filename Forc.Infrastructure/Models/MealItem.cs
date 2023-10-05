using Forc.Infrastructure.Models.Base;

namespace Forc.Infrastructure.Models
{
    /// <summary>
    /// Элемент приема пищи
    /// </summary>
    public class MealItem : BaseEntity<Guid>
    {
        /// <summary>
        /// ID приема пищи
        /// </summary>
        public Guid MealId { get; set; }

        /// <summary>
        /// Прием пищи
        /// </summary>
        public Meal Meal { get; set; }

        /// <summary>
        /// Id блюда
        /// </summary>
        public Guid DishId { get; set; }

        /// <summary>
        /// Блюдо
        /// </summary>
        public Dish Dish { get; set; }

        /// <summary>
        /// Вес блюда
        /// </summary>
        public double DishWeightG { get; set; }
    }
}
