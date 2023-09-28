namespace Forc.WebApi.Dto
{
    /// <summary>
    /// Вес пользователя
    /// </summary>
    public class WeightConditionViewModel
    {
        public Guid? Id { get; set; }

        /// <summary>
        /// ID пользователя
        /// </summary>
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
