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

            var registerResult = await _userService.RegisterAsync(user);
            
            if (!registerResult.Success)
            {
                return StatusCode(400, new { Message = registerResult.Message });
            }
            else
            {
                var token = _tokenService.GenerateToken(registerResult.Data);
                return StatusCode(200, new { Data = token });
            }
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> LoginAsync([FromBody] UserLoginPL loginUser)
        {
            var user = new UserBLL
            {
                Email = loginUser.Email,
                Password = loginUser.Password
            };

            var loginResult = await _userService.LoginAsync(user);

            if (!loginResult.Success)
            {
                return StatusCode(401, new { Message = loginResult.Message });
            }
            else
            {
                var token = _tokenService.GenerateToken(loginResult.Data);
                return StatusCode(200, new { Data = token });
            }
        }
    }
}