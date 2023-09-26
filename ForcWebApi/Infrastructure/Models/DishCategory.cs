using ForcWebApi.Infrastructure.Entities;

namespace ForcWebApi.Infrastructure.Models
{
    /// <summary>
    /// Категории блюд
    /// </summary>
    public class DishCategory: BaseEntity<Guid>
    {
        /// <summary>
        /// Наименование группы
        /// </summary>
        public string CategoryName { get; set; }

        /// <summary>
        /// Блюда, входящие в группу
        /// </summary>
        public ICollection<Dish> Dishes { get; set; }
    }
}
