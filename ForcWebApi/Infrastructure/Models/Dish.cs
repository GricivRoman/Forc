using System.ComponentModel.DataAnnotations.Schema;

namespace ForcWebApi.Infrastructure.Entities
{
    /// <summary>
    /// Блюдо
    /// </summary>
    public class Dish : BaseEntity<Guid>
    {
        /// <summary>
        /// Наименование блюда
        /// </summary>
        public string DishName { get; set; }

        /// <summary>
        /// Ресурсная спецификация
        /// </summary>
        public ResourseSpecification ResourseSpecification { get; set; }

        /// <summary>
        /// Id песурсной спецификации
        /// </summary>
        [ForeignKey(nameof(ResourseSpecification))]
        public Guid ResourseSpecificationId { get; set; }

        /// <summary>
        /// В каких наборах блюд присутствует это блюдо
        /// </summary>
        public ICollection<UserDishCollection> UserDishCollections { get; set; }
    }
}
