using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Uroboro.Common.Models;
using Uroboro.SL.WebAPI.Helpers;
using Uroboro.SL.WebAPI.Services;

namespace Uroboro.SL.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TokenController : ControllerBase
    {
        private IConfiguration _config;
        private IUsersService _usersService = null;

        public TokenController(IConfiguration config, IUsersService usersService)
        {
            this._config = config;
            this._usersService = usersService;
        }

        [AllowAnonymous]
        [HttpPost("GetToken")]
        public IActionResult GetToken([FromBody] JwtAuthRequest authData)
        {
            IActionResult response = Unauthorized();

            var user = AuthHelper.Authenticate(authData, this._usersService.GetUsers());
            if (user == null)
            {
                response = BadRequest(new { error = $"Invalid User: [{authData.Username}]" });
                return response;
            }

            // Build JWT
            var tokenString = AuthHelper.BuildToken(user, _config["Jwt:Key"], _config["Jwt:Issuer"]);
            response = Ok(new JwtAuthResponse() { Token = tokenString });

            return response;
        }
    }
}
