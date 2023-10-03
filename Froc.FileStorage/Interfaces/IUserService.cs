using Forc.FileStorage.Models;

namespace Forc.FileStorage.Interfaces
{
    public interface IUserService
    {
        Task<UserModel> SaveUser(UserModel user);
        Task<UserModel> GetUser(Guid id);
    }
}
