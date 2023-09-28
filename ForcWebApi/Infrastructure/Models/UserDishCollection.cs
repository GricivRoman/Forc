using System.ComponentModel.DataAnnotations.Schema;

namespace Forc.WebApi.Infrastructure.Entities
{
    /// <summary>
    /// Каталог блюд пользователя
    /// </summary>
    public class UserDishCollection : BaseEntity<Guid>
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
        /// Набор блюд
        /// </summary>
        public ICollection<Dish> Dishes { get; set; }
    }
}
