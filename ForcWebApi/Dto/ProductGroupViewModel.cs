﻿namespace ForcWebApi.Dto
{
    /// <summary>
    /// Группа товаров
    /// </summary>
    public class ProductGroupViewModel
    {
        public Guid? Id { get; set; }

        /// <summary>
        /// Наименование группы товаров
        /// </summary>
        public string GroupName { get; set; }

        /// <summary>
        /// Товары, входящие в группу
        /// </summary>
        public ICollection<ProductViewModel> Products { get; set; }
    }
}
