namespace ForcWebApi.Dto
{
    /// <summary>
    /// Элемент ресурсной спецификации. Продукт и количество
    /// </summary>
    public class CompositionItemViewModel
    {
        public Guid? Id { get; set; }

        /// <summary>
        /// ID ресурсной спецификации
        /// </summary>
        public Guid ResourceSpecificationId { get; set; }

        /// <summary>
        /// Id используемого продукта
        /// </summary>
        public Guid ProductId { get; set; }

        /// <summary>
        /// Используемый продукт
        /// </summary>
        public ProductViewModel Product { get; set; }

        /// <summary>
        /// Вес продукта
        /// </summary>
        public double ProductWeightG { get; set; }
    }
}
