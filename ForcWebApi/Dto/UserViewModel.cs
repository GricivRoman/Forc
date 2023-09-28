using Forc.WebApi.Enums;

namespace Forc.WebApi.Dto
{
    public class UserViewModel
    {
        public Guid Id { get; set; }

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
        /// Категория физической активности
        /// </summary>
        public Guid? PhysicalActivityId { get; set; }

        /// <summary>
        /// Категория физической активности
        /// </summary>
        public PhysicalActivityViewModel PhysicalActivity { get; set; }

        /// <summary>
        /// Взвешивания
        /// </summary>
        public ICollection<WeightConditionViewModel> WeightConditions { get; set; }

        /// <summary>
        /// Цели
        /// </summary>
        public ICollection<UserTargetViewModel> Targets { get; set; }

        /// <summary>
        /// Приемы пищи
        /// </summary>
        public ICollection<MealViewModel> Meals { get; set; }

        /// <summary>
        /// Id каталога блюд пользователя
        /// </summary>
        public Guid UserDishCollectionId { get; set; }

        /// <summary>
        /// Каталог блюд пользователя
        /// </summary>
        public UserDishCollectionViewModel UserDishCollection { get; set; }

        /// <summary>
        /// Рост
        /// </summary>
        public double? Height { get; set; }
    }
}
