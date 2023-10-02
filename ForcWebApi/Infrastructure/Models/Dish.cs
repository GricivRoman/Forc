using Forc.WebApi.Infrastructure.Models;

namespace Forc.WebApi.Infrastructure.Entities
{
    /// <summary>
    /// Блюдо
    /// </summary>
    public class Dish : EntityWithName<Guid>
    {
        /// <summary>
        /// Id песурсной спецификации
        /// </summary>
        public Guid ResourceSpecificationId { get; set; }

        /// <summary>
        /// Ресурсная спецификация
        /// </summary>
        public ResourceSpecification ResourseSpecification { get; set; }

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
