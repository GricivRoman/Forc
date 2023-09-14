namespace ForcWebApi.Infrastructure.Entities
{
    /// <summary>
    /// Продукт
    /// </summary>
    public class Product : BaseFoodEntity<Guid>
    {
        /// <summary>
        /// Наименование
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Рецепты, в которых используется продукт
        /// </summary>
        public ICollection<CompositionItem> CompositionItems { get; set; }
    }
}
