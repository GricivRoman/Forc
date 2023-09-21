using ForcWebApi.Validation;
using Microsoft.AspNetCore.Mvc;

namespace ForcWebApi.Controllers
{
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    public class BaseController : Controller
    {
    }
}
