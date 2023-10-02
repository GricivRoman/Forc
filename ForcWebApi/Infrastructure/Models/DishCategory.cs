using Forc.WebApi.Infrastructure.Entities;

namespace Forc.WebApi.Infrastructure.Models
{
    /// <summary>
    /// Категории блюд
    /// </summary>
    public class DishCategory: EntityWithName<Guid>
    {
        /// <summary>
        /// Блюда, входящие в группу
        /// </summary>
        public ICollection<Dish> Dishes { get; set; }
    }
}
