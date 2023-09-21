using ForcWebApi.Dto;
using ForcWebApi.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ForcWebApi.Controllers
{
    public class AuthController : BaseController
    {
        private readonly IAccountService _accountService;

        public AuthController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpPost]
        [Route("/account/checkin")]
        public async Task<IActionResult> CheckInAsync([FromBody]CheckInViewModel userModel)
        {
            await _accountService.CreateUserAsync(userModel);
            return Ok();
        }

        [HttpPost]
        [Route("/account/login")]
        public async Task<IActionResult> CreateTokenAsync([FromBody] LoginViewModel model)
        {
            var creds = await _accountService.CreateTokenAsync(model);
            return Ok(creds);
        }
    }
}
