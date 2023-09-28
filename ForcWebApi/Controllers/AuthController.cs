using ForcWebApi.Dto;
using ForcWebApi.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ForcWebApi.Controllers
{
    [Route("/account")]
    public class AuthController : BaseController
    {
        private readonly IAccountService _accountService;

        public AuthController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpPost]
        [Route("/checkin")]
        public async Task<IActionResult> CheckInAsync([FromBody]CheckInViewModel userModel)
        {
            await _accountService.CreateUserAsync(userModel);
            return Ok();
        }

        [HttpPost]
        [Route("/login")]
        public async Task<IActionResult> CreateTokenAsync([FromBody] LoginViewModel model)
        {
            var creds = await _accountService.CreateTokenAsync(model);
            return Ok(creds);
        }
    }
}
