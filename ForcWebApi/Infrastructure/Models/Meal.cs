using System.ComponentModel.DataAnnotations.Schema;

namespace ForcWebApi.Infrastructure.Entities
{
    /// <summary>
    /// Прием пищи
    /// </summary>
    public class Meal : BaseEntity<Guid>
    {
        /// <summary>
        /// ID пользователя
        /// </summary>
        public Guid UserId { get; set; }

        /// <summary>
        /// Пользователь
        /// </summary>
        public User User { get; set; }

        /// <summary>
        /// Время приема пищи
        /// </summary>
        public DateTime MealTime { get; set; }

        /// <summary>
        /// Набор блюд
        /// </summary>
        public ICollection<MealItem> MealItems { get; set; }
    }
}
