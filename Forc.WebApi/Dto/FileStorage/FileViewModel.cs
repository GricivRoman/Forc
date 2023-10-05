using System.Text.Json.Serialization;

namespace Forc.WebApi.Dto.FileStorage
{
    public class FileViewModel
    {
        public Guid Id { get; set; }

        public byte[] File { get; set; }
    }
}
