namespace ForcWebApi.Dto
{
    /// <summary>
    /// Дневная норма потребления соответствующая цели
    /// </summary>
    public class DailyRateViewModel
    {
        public Guid? Id { get; set; }

        /// <summary>
        /// Id цели
        /// </summary>
        public Guid UserTargetId { get; set; }

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
