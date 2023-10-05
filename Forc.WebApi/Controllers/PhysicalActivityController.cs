using Forc.WebApi.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Forc.WebApi.Controllers
{
    [Authorize]
    [Route("/physical-activity")]
    public class PhysicalActivityController : BaseController
    {
        private readonly IPhysicalActivityService _physicalActivityService;

        public PhysicalActivityController(IPhysicalActivityService physicalActivityService)
        {
            _physicalActivityService = physicalActivityService;
        }

        [HttpGet]
        [Route("select-list")]
        public async Task<IActionResult> GetPhysicalActivities()
        {
            var physicalActivities = await _physicalActivityService.GetPhysicalActivitySelectItems();
            return Ok(physicalActivities);
        }
    }
}
