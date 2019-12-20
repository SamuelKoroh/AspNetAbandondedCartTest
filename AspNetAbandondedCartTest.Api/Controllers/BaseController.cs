using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace AspNetAbandondedCartTest.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController : ControllerBase
    {
        protected string GetUserId() => User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value;

        [ApiExplorerSettings(IgnoreApi = true)]
        public IActionResult Success(object data)
        {
            return base.Ok(new { Status = "success", data });
            
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        public IActionResult Error(object error)
        {
            return base.BadRequest(new { Status = "error", error });

        }
        [ApiExplorerSettings(IgnoreApi = true)]
        public IActionResult Errors(IEnumerable<object> errors)
        {
            return base.BadRequest(new { Status = "error", errors });

        }

        public override OkObjectResult Ok([ActionResultObjectValue] object value)
        {
            return base.Ok(new { Status = StatusCodes.Status200OK, data = value });
        }
    }
}