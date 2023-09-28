namespace ForcWebApi.Dto
{
    /// <summary>
    /// Категории блюд
    /// </summary>
    public class DishCategoryViewModel
    {
        public Guid? Id { get; set; }

        /// <summary>
        /// Наименование группы
        /// </summary>
        public string CategoryName { get; set; }

        /// <summary>
        /// Блюда, входящие в группу
        /// </summary>
        public ICollection<DishViewModel> Dishes { get; set; }
    }
}
