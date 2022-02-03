using Infrastucture.Data;
using Microsoft.AspNetCore.Mvc;
using webapi1.API.Errors;

namespace webapi1.API.Controllers
{
    public class BuggiController : BaseApiController
    {
        public StoreContext StoreContext { get; }

        public BuggiController(StoreContext storeContext)
        {
            StoreContext = storeContext;
        }


        [HttpGet("notfound")]
        public ActionResult GetNotFoundRequest()
        {
            var athing = StoreContext.Products.Find(1222);
            if (athing == null)
            {

                return NotFound(new ApiResponse(404));
            }


            return Ok();
        }

        [HttpGet("servererror")]
        public ActionResult GetServerError()
        {
            var athing = StoreContext.Products.Find(1222);
            var referencException = athing.ToString();
            return Ok();
        }

        [HttpGet("badrequest")]
        public ActionResult GetBadRequest()
        {
            return BadRequest();
        }

        [HttpGet("badrequest/{id}")]
        public ActionResult GetBadRequestIdNotFound(int id)
        {
            return Ok();
        }
    }
}
