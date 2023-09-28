namespace ForcWebApi.Dto
{
    public class ProductViewModel
    {
        public Guid? Id { get; set; }

        /// <summary>
        /// Наименование
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Элементы рецептов, в которых исполльзуется продукт
        /// </summary>
        public ICollection<CompositionItemViewModel> CompositionItems { get; set; }

        /// <summary>
        /// Группа, в которую входит продукт
        /// </summary>
        public Guid? ProductGroupId { get; set; }

        /// <summary>
        /// Гуппа, в которую входит продукт
        /// </summary>
        public ProductGroupViewModel ProductGroup { get; set; }

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
