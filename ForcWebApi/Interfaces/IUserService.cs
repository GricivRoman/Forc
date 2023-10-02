using Forc.WebApi.Dto;

namespace Forc.WebApi.Interfaces
{
    public interface IUserService
    {
        Task<UserViewModel> GetUserAsync(Guid id);

        Task UpdateUserAsync(UserViewModel model);

        Task DeleteUserAsync(Guid id);
    }
}
