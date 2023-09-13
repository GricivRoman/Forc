namespace ForcWebApi.Infrastructure
{
    public class BaseEntity<TKey>
    {
        public TKey Id { get; set; }
    }
}
