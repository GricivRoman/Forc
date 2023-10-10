namespace Forc.WebApi.Dto
{
    /// <summary>
    /// Цель пользователя
    /// </summary>
    public class UserTargetViewModel
    {
        public Guid? Id { get; set; }

        /// <summary>
        /// ID пользователя
        /// </summary>
        public Guid UserId { get; set; }

        /// <summary>
        /// Пользователь
        /// </summary>
        public UserViewModel User { get; set; }

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
        public Guid? DailyRateId { get; set; }

        /// <summary>
        /// Дневная норма в соответствии с актуальной целью
        /// </summary>
        public DailyRateViewModel DailyRate { get; set; }
    }
}
