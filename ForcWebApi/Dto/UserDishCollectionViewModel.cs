namespace ForcWebApi.Dto
{
    /// <summary>
    /// Каталог блюд пользователя
    /// </summary>
    public class UserDishCollectionViewModel
    {
        public Guid? Id { get; set; }

        /// <summary>
        /// ID пользователя
        /// </summary>
        public Guid UserId { get; set; }

        /// <summary>
        /// Набор блюд
        /// </summary>
        public ICollection<DishViewModel> Dishes { get; set; }
    }
}
