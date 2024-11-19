using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using UserService.Dtos;
using UserService.Interfaces;

namespace UserService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        // Endpoint for user authentication
        [HttpPost("authenticate")]
        public async Task<IActionResult> Authenticate([FromBody] AuthDto authDto)
        {
            var response = await _userService.AuthenticateUser(authDto);

            if (!response.IsAuthenticated)
            {
                return Unauthorized(new { message = response.ErrorMessage });
            }

            return Ok(new { token = response.Token });
        }        
    }
}
