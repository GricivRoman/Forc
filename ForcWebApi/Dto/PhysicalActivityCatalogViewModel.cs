namespace ForcWebApi.Dto
{
    /// <summary>
    /// Набор категорий физической активности
    /// </summary>
    public class PhysicalActivityCatalogViewModel
    {
        public Guid? Id { get; set; }

        /// <summary>
        /// Наименование
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Описание
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Множитель физической активности
        /// </summary>
        public double PhysicalActivityMultiplier { get; set; }

        /// <summary>
        /// Пользователи, у которых установлена категория физ. активности
        /// </summary>
        public ICollection<UserViewModel> Users { get; set; }
    }
}
