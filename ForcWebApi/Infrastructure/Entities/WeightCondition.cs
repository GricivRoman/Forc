using System.ComponentModel.DataAnnotations.Schema;

namespace ForcWebApi.Infrastructure.Entities
{
    /// <summary>
    /// Вес пользователя
    /// </summary>
    public class WeightCondition : BaseEntity<Guid>
    {
        /// <summary>
        /// Пользователь
        /// </summary>
        [ForeignKey(nameof(User))]
        public Guid UserId { get; set; }

        /// <summary>
        /// Дата взвешевания
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// Вес
        /// </summary>
        public double BodyWeight { get; set; }
    }
}
