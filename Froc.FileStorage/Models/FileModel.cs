using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Forc.FileStorage.Models
{
    public class FileModel
    {
        [BsonGuidRepresentation(GuidRepresentation.Unspecified)]
        public Guid Id { get; set; }

        public byte[] File { get; set; }
    }
}
