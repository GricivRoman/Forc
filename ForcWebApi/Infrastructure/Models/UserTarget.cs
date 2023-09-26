using System.ComponentModel.DataAnnotations.Schema;

namespace ForcWebApi.Infrastructure.Entities
{
    /// <summary>
    /// Цель пользователя
    /// </summary>
    public class UserTarget : BaseEntity<Guid>
    {
        /// <summary>
        /// Пользователь
        /// </summary>
        public Guid UserId { get; set; }

        /// <summary>
        /// Актуальность
        /// </summary>
        public bool Relevance { get; set; }

        /// <summary>
        /// Дата начала
        /// </summary>
        public DateTime DateStart { get; set; }

        /// <summary>
        /// Дата окончания
        /// </summary>
        public DateTime DateFinish { get; set; }

        /// <summary>
        /// Текущий вес тела
        /// </summary>
        public double CurrentBodyWeight { get; set; }

        /// <summary>
        /// Целевой вес тела
        /// </summary>
        public double TargetBodyWeight { get; set; }

        /// <summary>
        /// ID дневной нормы в соответствии с актуальной целью
        /// </summary>
        public Guid DailyRateId { get; set; }

        /// <summary>
        /// Дневная норма в соответствии с актуальной целью
        /// </summary>
        public DailyRate DailyRate { get; set; }
    }
}
