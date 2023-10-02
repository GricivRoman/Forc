namespace Forc.WebApi.Infrastructure
{
    public class EntityWithName<Tkey> : BaseEntity<Tkey>
    {
        public string Name { get; set; }
    }
}
