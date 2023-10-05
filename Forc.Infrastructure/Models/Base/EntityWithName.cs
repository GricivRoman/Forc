namespace Forc.Infrastructure.Models.Base
{
    public class EntityWithName<Tkey> : BaseEntity<Tkey>
    {
        public string Name { get; set; }
    }
}
