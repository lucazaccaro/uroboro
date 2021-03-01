using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Uroboro.SL.WebAPI.Services;

namespace Uroboro.SL.WebAPI.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class SecureController : Controller
    {
        private IConfiguration _config;
        private IUsersService _usersService = null;

        public SecureController(IConfiguration config, IUsersService usersService)
        {
            this._config = config;
            this._usersService = usersService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var users = this._usersService.GetUsers();
            return Ok(users);
        }

        [HttpPost]
        public IActionResult Post()
        {
            var users = this._usersService.GetUsers();
            return Ok(users);
        }
    }
}
