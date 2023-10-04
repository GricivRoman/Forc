using Forc.WebApi.Dto;
using Forc.WebApi.Dto.FileStorage;

namespace Forc.WebApi.Interfaces
{
    public interface IUserService
    {
        Task<UserViewModel> GetUserAsync(Guid id);

        Task<Guid> UpdateUserAsync(UserViewModel model);

        Task DeleteUserAsync(Guid id);

        Task UploadPhotoAsync(FileToUploadViewModel fileModel);

        Task<FileViewModel> GetPhotoAsync(Guid id);
    }
}
