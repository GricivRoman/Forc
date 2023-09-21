using System.ComponentModel.DataAnnotations.Schema;

namespace ForcWebApi.Infrastructure.Entities
{
    /// <summary>
    /// Каталог блюд пользователя
    /// </summary>
    public class UserDishCollection : BaseEntity<Guid>
    {
        /// <summary>
        /// Пользоваталь
        /// </summary>
        [ForeignKey(nameof(User))]
        public Guid UserId { get; set; }

        /// <summary>
        /// Набор блюд
        /// </summary>
        public ICollection<Dish> Dishes { get; set; }
    }
}
