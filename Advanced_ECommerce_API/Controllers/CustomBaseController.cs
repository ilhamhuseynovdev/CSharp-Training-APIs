using Advanced_ECommerce_API.Utilities.Results;
using Microsoft.AspNetCore.Mvc;

namespace Advanced_ECommerce_API.Controllers
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
