using Forc.WebApi.Dto;
using Forc.WebApi.Dto.FileStorage;
using Forc.WebApi.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Forc.WebApi.Controllers
{
    [Route("/user")]
    [Authorize]
    public class UserController : BaseController
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
            var user = await _userService.GetUserAsync(id);
            return Ok(user);
        }

        [HttpPut]
        [Route("")]
        public async Task<IActionResult> UpdateUser([FromBody]UserViewModel model)
        {
            var userId = await _userService.UpdateUserAsync(model);
            return Ok(userId);
        }

        [HttpPost]
        [Route("photo")]
        public async Task<IActionResult> UploadPhoto([FromForm]FileToUploadViewModel fileModel)
        {
            await _userService.UploadPhotoAsync(fileModel);
            return Ok();
        }

        // TODO нормальный нэйминг роутинга
        [HttpGet]
        [Route("photo/{id}")]
        public async Task<IActionResult> UploadPhoto(Guid id)
        {
            var userPhoto = await _userService.GetPhotoAsync(id);
            return Ok(userPhoto);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteUser(Guid id)
        {
            await _userService.DeleteUserAsync(id);
            return Ok();
        }
    }
}
