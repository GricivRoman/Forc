using Forc.FileStorage.Helpers;
using Forc.FileStorage.Interfaces;
using Forc.FileStorage.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

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
            user.Photo = ImapeHelper.GetImage(Convert.ToBase64String(user.Photo));
            return Ok(user);
        }

        [HttpPost]
        [HttpPut]
        [Route("")]
        public async Task<IActionResult> SaveUser(FileUpload fileObj)
        {
            UserModel user = JsonConvert.DeserializeObject<UserModel>(fileObj.Model);
            if (fileObj.File.Length > 0)
            {
                using(var ms = new MemoryStream())
                {
                    fileObj.File.CopyTo(ms);
                    var fileBytes = ms.ToArray();

                    user.Photo= fileBytes;
                    user = await _userService.SaveUser(user);

                    if(user.Id != Guid.Empty)
                    {
                        return Ok();
                    }
                }
            }
            return BadRequest("Save filed");
        }
    }
}
