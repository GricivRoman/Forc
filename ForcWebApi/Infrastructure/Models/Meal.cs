using System.ComponentModel.DataAnnotations.Schema;

namespace ForcWebApi.Infrastructure.Entities
{
    /// <summary>
    /// Прием пищи
    /// </summary>
    public class Meal : BaseEntity<Guid>
    {
        /// <summary>
        /// Пользователь
        /// </summary>
        public Guid UserId { get; set; }
        
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
