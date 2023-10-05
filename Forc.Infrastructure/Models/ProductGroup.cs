using Forc.Infrastructure.Models.Base;

namespace Forc.Infrastructure.Models
{
    /// <summary>
    /// Группа товаров
    /// </summary>
    public class ProductGroup : EntityWithName<Guid>
    {
        /// <summary>
        /// Товары, входящие в группу
        /// </summary>
        public ICollection<Product> Products { get; set; }
    }
}
