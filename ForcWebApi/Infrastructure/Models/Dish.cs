using ForcWebApi.Infrastructure.Models;
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
        public ResourceSpecification ResourseSpecification { get; set; }

        /// <summary>
        /// Id песурсной спецификации
        /// </summary>
        public Guid ResourceSpecificationId { get; set; }

        /// <summary>
        /// В каких наборах блюд присутствует это блюдо
        /// </summary>
        public ICollection<UserDishCollection> UserDishCollections { get; set; }

        /// <summary>
        /// Категории, в которые входит блюдо
        /// </summary>
        public ICollection<DishCategory> Categoties { get; set; }

        /// <summary>
        /// Приемы пищи, в которые входит блюдо
        /// </summary>
        public ICollection<MealItem> MealItems { get; set; }
    }
}
