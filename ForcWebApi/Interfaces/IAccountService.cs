using Forc.WebApi.Dto;

namespace Forc.WebApi.Interfaces
{
    public interface IAccountService
    {
        Task CreateUserAsync(CheckInViewModel userModel);

        Task<CredentialsViewModel> CreateTokenAsync(LoginViewModel model);
    }
}