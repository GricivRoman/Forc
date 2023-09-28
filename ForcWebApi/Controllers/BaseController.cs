using Forc.WebApi.Validation;
using Microsoft.AspNetCore.Mvc;

namespace Forc.WebApi.Controllers
{
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    public class BaseController : Controller
    {
    }
}
