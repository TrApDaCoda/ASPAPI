using Microsoft.AspNetCore.Mvc;
using TestApiDOTNetCore.Services;

namespace TestApiDOTNetCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly TokenServices _tokenService;

        public TokenController(TokenServices tokenService)
        {
            _tokenService = tokenService;
        }

        [HttpGet("UserToken")]
        public IActionResult GetUserToken()
        {
            var token = _tokenService.GenerateToken("User");
            return Ok(new { Token = token });
        }

        [HttpGet("AdminToken")]
        public IActionResult GetAdminToken()
        {
            var token = _tokenService.GenerateToken("Admin");
            return Ok(new { Token = token });
        }
    }
}
