using System.ComponentModel.DataAnnotations.Schema;
using Forc.Infrastructure.Models.Base;

namespace Forc.Infrastructure.Models
{
    /// <summary>
    /// Дневная норма потребления соответствующая цели
    /// </summary>
    public class DailyRate : BaseEntity<Guid>
    {
        /// <summary>
        /// Id цели
        /// </summary>
        public Guid UserTargetId { get; set; }

        /// <summary>
        /// Цель
        /// </summary>
        public UserTarget UserTarget { get; set; }

        /// <summary>
        /// Норма потребления каллорий
        /// </summary>
        public double CaloriesRate { get; set; }

        /// <summary>
        /// Норма потребления углеводов
        /// </summary>
        public double CarbohydrateRate { get; set; }

        /// <summary>
        /// Норма потребления жиров
        /// </summary>
        public double FatRate { get; set; }

        /// <summary>
        /// Норма потребления белков
        /// </summary>
        public double ProteinRate { get; set; }
    }
}
