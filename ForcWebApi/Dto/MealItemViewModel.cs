namespace ForcWebApi.Dto
{
    /// <summary>
    /// Элемент приема пищи
    /// </summary>
    public class MealItemViewModel
    {
        public Guid? Id { get; set; }

        /// <summary>
        /// ID приема пищи
        /// </summary>
        public Guid MealId { get; set; }

        /// <summary>
        /// Id блюда
        /// </summary>
        public Guid DishId { get; set; }

        /// <summary>
        /// Блюдо
        /// </summary>
        public DishViewModel Dish { get; set; }

        /// <summary>
        /// Вес блюда
        /// </summary>
        public double DishWeightG { get; set; }
    }
}
