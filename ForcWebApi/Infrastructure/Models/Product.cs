using ForcWebApi.Infrastructure.Models;

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
        /// Элементы рецептов, в которых исполльзуется продукт
        /// </summary>
        public ICollection<CompositionItem> CompositionItems { get; set; }


        /// <summary>
        /// Группа, в которую входит продукт
        /// </summary>
        public Guid? ProductGroupId { get; set; }

        public ProductGroup ProductGroup { get; set; }
    }
}
