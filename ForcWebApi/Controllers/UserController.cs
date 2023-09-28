using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace ForcWebApi.Controllers
{
    [Route("/user")]
    public class UserController : BaseController
    {
        [HttpGet]
        [Route("{id}")]
        public IActionResult GetUser(Guid id)
        {
            return Ok();
        }

        [HttpPost, HttpPut]
        [Route("")]
        public Task<IActionResult> SaveUser(Guid id)
        {
            return null;
        }

        [HttpDelete]
        [Route("{id}")]
        public Task<IActionResult> DeleteUser(Guid id)
        {
            return null;
        }
    }
}
