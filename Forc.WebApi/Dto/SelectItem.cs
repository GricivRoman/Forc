namespace Forc.WebApi.Dto
{
    /// <summary>
    /// Пара ключ значение для выведение в селекторы
    /// </summary>
    /// <typeparam Id="Tkey"></typeparam>
    public class SelectItem<Tkey>
    {
        public Tkey Id { get; set; }

        public string Value { get; set; }
    }
}
