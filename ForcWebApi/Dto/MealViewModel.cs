namespace Forc.WebApi.Dto
{
    /// <summary>
    /// Прием пищи
    /// </summary>
    public class MealViewModel
    {
        public Guid? Id { get; set; }

        /// <summary>
        /// ID пользователя
        /// </summary>
        public Guid UserId { get; set; }

        /// <summary>
        /// Время приема пищи
        /// </summary>
        public DateTime MealTime { get; set; }

        /// <summary>
        /// Набор блюд
        /// </summary>
        public ICollection<MealItemViewModel> MealItems { get; set; }
    }
}
