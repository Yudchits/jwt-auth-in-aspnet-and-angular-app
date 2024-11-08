using JwtAuthentication.Logic.Common.Models;
using JwtAuthentication.Logic.Common.Services;
using JwtAuthentication.WebAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace JwtAuthentication.WebAPI.Controllers
{
    [ApiController]
    [Route("api/user")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ITokenService _tokenService;

        public UserController(IUserService userService, ITokenService tokenService)
        {
            _userService = userService;
            _tokenService = tokenService;
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> RegisterAsync([FromBody] UserRegisterPL registerUser)
        {
            var user = new UserBLL
            {
                Email = registerUser.Email,
                Password = registerUser.Password
            };

            var createResult = await _userService.CreateAsync(user);
            
            if (!createResult.Success)
            {
                return StatusCode(400, new { Message = createResult.Message });
            }
            else
            {
                var token = _tokenService.GenerateToken(createResult.Data);
                return StatusCode(200, new { Data = token });
            }
        }
    }
}