using ForcWebApi.Dto;

namespace ForcWebApi.Interfaces
{
    public interface IAccountService
    {
        Task CreateUserAsync(UserViewModel userModel);
    }
}