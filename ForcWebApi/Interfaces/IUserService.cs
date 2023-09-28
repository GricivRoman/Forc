using Forc.WebApi.Dto;

namespace Forc.WebApi.Interfaces
{
    public interface IUserService
    {
        Task<UserViewModel> GetUser(Guid id);

        Task UpdateUser(UserViewModel model);

        Task DeleteUser(Guid id);
    }
}
