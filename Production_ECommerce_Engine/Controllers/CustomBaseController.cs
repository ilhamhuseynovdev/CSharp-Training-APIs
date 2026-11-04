using Production_ECommerce_Engine.Utilities.Results;
using Microsoft.AspNetCore.Mvc;

namespace Production_ECommerce_Engine.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomBaseController : ControllerBase
    {
        [NonAction]
        public IActionResult CreateActionResult<T>(ServiceResult<T> response)
        {
            return new ObjectResult(response)
            {
                StatusCode = response.StatusCode
            };
        }
    }
}
