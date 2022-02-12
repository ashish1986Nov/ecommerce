using Microsoft.AspNetCore.Mvc;
using webapi1.API.Errors;

namespace webapi1.API.Controllers
{
    [Route("customerror/{code}")]
    [ApiExplorerSettings(IgnoreApi =true)]
    public class customerrorController : BaseApiController
    {
        public IActionResult customerror(int code)
        {
            return new ObjectResult(new ApiResponse(code));

        }
    }
}
