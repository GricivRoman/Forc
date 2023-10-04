namespace Forc.WebApi.Dto.FileStorage
{
    public class FileToUploadViewModel
    {
        public Guid Id { get; set; }
        public IFormFile File { get; set; }
    }
}
