using System.ComponentModel.DataAnnotations.Schema;

namespace ForcWebApi.Infrastructure.Entities
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
        /// Блюдо
        /// </summary>
        public Guid DishId { get; set; }

        /// <summary>
        /// Вес блюда
        /// </summary>
        public double DishWeightG { get; set; }
    }
}
