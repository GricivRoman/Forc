using System.ComponentModel.DataAnnotations.Schema;

namespace Forc.WebApi.Infrastructure.Entities
{
    /// <summary>
    /// Вес пользователя
    /// </summary>
    public class WeightCondition : BaseEntity<Guid>
    {
        /// <summary>
        /// ID пользователя
        /// </summary>
        public Guid UserId { get; set; }

        /// <summary>
        /// Пользователь
        /// </summary>
        public User User { get; set; }

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
