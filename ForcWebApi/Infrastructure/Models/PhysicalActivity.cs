namespace Forc.WebApi.Infrastructure.Entities
{
    /// <summary>
    /// Набор категорий физической активности
    /// </summary>
    public class PhysicalActivity : EntityWithName<Guid>
    {
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
        public ICollection<User> Users { get; set; }
    }
}
