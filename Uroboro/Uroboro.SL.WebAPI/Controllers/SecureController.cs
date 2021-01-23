using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Uroboro.SL.WebAPI.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class SecureController : Controller
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Secure Get OK");
        }

        [HttpPost]
        public IActionResult Post()
        {
            return Ok("Secure Post OK");
        }
    }
}
