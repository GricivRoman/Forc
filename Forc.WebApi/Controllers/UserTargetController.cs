using Forc.WebApi.Dto;
using Forc.WebApi.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Forc.WebApi.Controllers
{
    [Authorize]
    [Route("/user-target")]
    public class UserTargetController : BaseController
    {
        private readonly IUserTargetService _userTargetService;

        public UserTargetController(IUserTargetService userTargetService)
        {
            _userTargetService = userTargetService;
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetUserTarget(Guid id)
        {
            var userTarget = await _userTargetService.GetTargetAsync(id);
            return Ok(userTarget);
        }

        [HttpGet]
        [Route("list")]
        public async Task<IActionResult> GetUserTargets()
        {
            var userTargets = await _userTargetService.GetTargetListAsync(User.Identity.Name);
            return Ok(userTargets);
        }

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> AddUserTarget([FromBody]UserTargetViewModel model)
        {
            var createdUserTargetId = await _userTargetService.AddTargetAsync(model);
            return Ok(createdUserTargetId);
        }

        [HttpPut]
        [Route("")]
        public async Task<IActionResult> EditUserTarget([FromBody] UserTargetViewModel model)
        {
            await _userTargetService.EditTargetAsync(model);
            return Ok();
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteUserTarget(Guid id)
        {
            await _userTargetService.DeleteTargetAsync(id);
            return Ok();
        }
    }
}
