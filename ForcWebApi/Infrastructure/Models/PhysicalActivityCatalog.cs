namespace ForcWebApi.Infrastructure.Entities
{
    /// <summary>
    /// Набор категорий физической активности
    /// </summary>
    public class PhysicalActivityCatalog : BaseEntity<Guid>
    {
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

        public ICollection<User> Users { get; set; }
    }
}
