﻿using ForcWebApi.Infrastructure.Entities;

namespace ForcWebApi.Infrastructure.Models
{
    /// <summary>
    /// Группа товаров
    /// </summary>
    public class ProductGroup : BaseEntity<Guid>
    {
        /// <summary>
        /// Наименование группы товаров
        /// </summary>
        public string GroupName { get; set; }

        /// <summary>
        /// Товары, входящие в группу
        /// </summary>
        public ICollection<Product> Products { get; set; }
    }
}