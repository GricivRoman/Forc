namespace Forc.WebApi.Dto
{
    /// <summary>
    /// Блюдо
    /// </summary>
    public class DishViewModel
    {
        public Guid? Id { get; set; }

        /// <summary>
        /// Наименование блюда
        /// </summary>
        public string DishName { get; set; }

        /// <summary>
        /// Id песурсной спецификации
        /// </summary>
        public Guid ResourceSpecificationId { get; set; }

        /// <summary>
        /// Ресурсная спецификация
        /// </summary>
        public ResourceSpecificationViewModel ResourseSpecification { get; set; }

        /// <summary>
        /// В каких наборах блюд присутствует это блюдо
        /// </summary>
        public ICollection<UserDishCollectionViewModel> UserDishCollections { get; set; }

        /// <summary>
        /// Категории, в которые входит блюдо
        /// </summary>
        public ICollection<DishCategoryViewModel> Categoties { get; set; }

        /// <summary>
        /// Приемы пищи, в которые входит блюдо
        /// </summary>
        public ICollection<MealItemViewModel> MealItems { get; set; }
    }
}
