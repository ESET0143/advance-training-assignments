using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AuthWbApiDemo.Controllers
{
    
    [ApiController]
    [Route("api/[controller]")]
    public class TestController : ControllerBase
    {
        [HttpGet("public")]
        public IActionResult Public() => Ok("This is a public endpoint");

        [Authorize]
        [HttpGet("private")]
        public IActionResult Private() => Ok("This is a private endpoint - authorized only");

        [Authorize(Roles = "Admin")]
        [HttpGet("admin")]
        public IActionResult Admin() => Ok("This endpoint is only for Admin");
    }
}
