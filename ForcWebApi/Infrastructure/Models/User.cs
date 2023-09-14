using ForcWebApi.Infrastructure.Enums;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace ForcWebApi.Infrastructure.Entities
{
    /// <summary>
    /// Пользователь
    /// </summary>
    public class User : IdentityUser
    {
        /// <summary>
        /// Имя пользователя
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// Дата рождения
        /// </summary>
        public DateTime? BirthDate { get; set; }

        /// <summary>
        /// Гендер
        /// </summary>
        public string? Gender { get; set; }

        /// <summary>
        /// Пол
        /// </summary>
        public SexEnum? Sex { get; set; }
        
        /// <summary>
        /// ID категории физической активности
        /// </summary>
        [ForeignKey(nameof(PhysicalActivityCatalog))]
        public Guid? PhysicalActivityId { get; set; }

        /// <summary>
        /// Категория физической активности
        /// </summary>
        public PhysicalActivityCatalog? PhysicalActivity { get; set; }

        /// <summary>
        /// Взвешивания
        /// </summary>
        public ICollection<WeightCondition>? WeightConditions { get; set; }

        /// <summary>
        /// Цели
        /// </summary>
        public ICollection<Target>? Targets { get; set; }

        /// <summary>
        /// Приемы пищи
        /// </summary>
        public ICollection<Meal>? Meals { get; set; }

        /// <summary>
        /// Id каталога блюд пользователя
        /// </summary>
        [ForeignKey(nameof(UserDishCollection))]
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
