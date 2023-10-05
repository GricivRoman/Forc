using Forc.WebApi.Dto.FileStorage;

namespace Forc.WebApi.Interfaces
{
    public interface IFileStorageService
    {
        Task UploadFileAsync(string path, FileToUploadViewModel fileModel);
        Task<FileViewModel> GetFileAsync(string path, Guid id);

    }
}
