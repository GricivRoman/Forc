using Forc.FileStorage.Interfaces;
using Forc.FileStorage.Models;
using Microsoft.AspNetCore.Mvc;

namespace Forc.FileStorage.Controllers
{
    [Route("/user")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetUser(Guid id)
        {
            var user = await _userService.GetUser(id);
            return Ok(user);
        }

        [HttpPost]
        [HttpPut]
        [Route("")]
        public async Task<IActionResult> SaveUser([FromForm]FileToUpload fileToUpload)
        {
            await _userService.SaveUser(fileToUpload);
            return Ok();
        }
    }
}
