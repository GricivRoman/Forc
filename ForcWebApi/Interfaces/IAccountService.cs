using ForcWebApi.Dto;

namespace ForcWebApi.Interfaces
{
    public interface IAccountService
    {
        Task CreateUserAsync(CheckInViewModel userModel);
    }
}