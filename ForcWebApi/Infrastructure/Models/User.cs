using Forc.WebApi.Enums;
using Microsoft.AspNetCore.Identity;

namespace Forc.WebApi.Infrastructure.Entities
{
    /// <summary>
    /// Пользователь
    /// </summary>
    public class User : IdentityUser<Guid>
    {
        /// <summary>
        /// Имя пользователя
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Дата рождения
        /// </summary>
        public DateTime? BirthDate { get; set; }

        /// <summary>
        /// Гендер
        /// </summary>
        public string Gender { get; set; }

        /// <summary>
        /// Пол
        /// </summary>
        public SexEnum? Sex { get; set; }
        
        /// <summary>
        /// ID категории физической активности
        /// </summary>
        public Guid? PhysicalActivityId { get; set; }

        /// <summary>
        /// Категория физической активности
        /// </summary>
        public PhysicalActivity PhysicalActivity { get; set; }

        /// <summary>
        /// Взвешивания
        /// </summary>
        public ICollection<WeightCondition> WeightConditions { get; set; }

        /// <summary>
        /// Цели
        /// </summary>
        public ICollection<UserTarget> Targets { get; set; }

        /// <summary>
        /// Приемы пищи
        /// </summary>
        public ICollection<Meal> Meals { get; set; }

        /// <summary>
        /// Id каталога блюд пользователя
        /// </summary>
        public Guid UserDishCollectionId { get; set; }

        /// <summary>
        /// Каталог блюд пользователя
        /// </summary>
        public UserDishCollection UserDishCollection { get; set; }

        /// <summary>
        /// Рост
        /// </summary>
        public double Height { get; set; }
    }
}
