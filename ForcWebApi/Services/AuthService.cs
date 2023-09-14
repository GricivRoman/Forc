using ForcWebApi.Dto;
using ForcWebApi.Infrastructure;
using ForcWebApi.Infrastructure.Entities;
using ForcWebApi.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace ForcWebApi.Services
{
    public class AuthService : IAccountService
    {
        private readonly DataContext _context;
        private readonly UserManager<User> _userManager;

        public AuthService(DataContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        public async Task CreateUserAsync(UserViewModel userModel)
        {
            var user = await _userManager.FindByEmailAsync(userModel.Email);
            if (user != null)
            {
                throw new InvalidOperationException("User with this E-mail already exists");
            } else
            {
                user = await _userManager.FindByNameAsync(userModel.UserName);
                if (user != null)
                {
                    throw new InvalidOperationException("User with this username already exists");
                }
                else
                {
                    user = new User
                    {
                        UserName = userModel.UserName,
                        Email = userModel.Email,
                        UserDishCollection = new UserDishCollection()
                    };
                    var result = await _userManager.CreateAsync(user, userModel.Password);
                    if (result != IdentityResult.Success)
                    {
                        throw new InvalidOperationException("Invalid password");
                    }
                }
            }
        }
    }
}
