using Forc.FileStorage.Models;

namespace Forc.FileStorage.Interfaces
{
    public interface IUserService
    {
        Task SaveUser(FileToUpload fileObj);
        Task<FileModel> GetUser(Guid id);
    }
}
