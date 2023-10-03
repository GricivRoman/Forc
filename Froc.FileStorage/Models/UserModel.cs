using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Forc.FileStorage.Models
{
    public class UserModel
    {
        [BsonGuidRepresentation(GuidRepresentation.Unspecified)]
        public Guid Id { get; set; }

        public byte[] Photo { get; set; }
    }
}
