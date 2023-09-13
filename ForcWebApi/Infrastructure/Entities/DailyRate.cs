using System.ComponentModel.DataAnnotations.Schema;

namespace ForcWebApi.Infrastructure.Entities
{
    /// <summary>
    /// Дневная норма потребления соответствующая цели
    /// </summary>
    public class DailyRate : BaseEntity<Guid>
    {
        /// <summary>
        /// Ссылка на цель
        /// </summary>
        [ForeignKey(nameof(Target))]
        public Guid TargetId { get; set; }

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
