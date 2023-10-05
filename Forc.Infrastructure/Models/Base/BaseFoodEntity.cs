namespace Forc.Infrastructure.Models.Base
{
    public class BaseFoodEntity<TKey> : BaseEntity<TKey>
    {
        /// <summary>
        /// Калорийность
        /// </summary>
        public double Calories { get; set; }

        /// <summary>
        /// Углеводы
        /// </summary>
        public double Carbohydrate { get; set; }

        /// <summary>
        /// Жиры
        /// </summary>
        public double Fat { get; set; }

        /// <summary>
        /// Белки
        /// </summary>
        public double Protein { get; set; }
    }
}
