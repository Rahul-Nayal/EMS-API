using Backend.Business;
using Backend.Model.Domain;
using Backend.Model.Dto;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuth _context;
        private readonly IJWToken jWToken;
        private readonly UserManager<IdentityUser> userManager;
        public AuthController(IAuth context, UserManager<IdentityUser> userManager, IJWToken jWToken)
        {
            _context = context;
            this.userManager = userManager;
            this.jWToken = jWToken;

        }
        //api/EMS/Register
        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequestDto registerRequestDto)
        {
            var identityResult = await _context.Register(registerRequestDto);
            if (identityResult != null)
            {
                return Ok("User was registered successfully Please Login!");
            }
            return BadRequest("Something went wrong");
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDto loginRequestDto)
        {
            var exisitingUser = await userManager.FindByEmailAsync(loginRequestDto.UserName);
            if (exisitingUser == null)
            {
                return Unauthorized("Invalid username");
            }
            var checkPassword = await userManager.CheckPasswordAsync(exisitingUser, loginRequestDto.Password);
            if (checkPassword == null)
            {
                return Unauthorized("Invalid password");
            }
            var roles = await userManager.GetRolesAsync(exisitingUser);
            if (roles == null)
            {
                return BadRequest("Something went wrong");
            }
            var tokenPair = jWToken.GenerateTokenPair(exisitingUser, roles.ToList());


            var response = new LoginResponseDto
            {
                JWToken = tokenPair.AccessToken,
                RefreshToken = tokenPair.RefreshToken,
                Permissions = tokenPair.Permissions 
            };
            return Ok(response);

        }


        [HttpPost]
        [Route("Refresh")]
        public async Task<IActionResult> Refresh([FromBody] RefreshRequestDto refreshRequestDto)
        {

            // var refreshTokenDomain = new RefreshToken
            // {
            //     Token = refreshRequestDto.Token
            // };
            var refreshTokenModel = await _context.RefreshAsync(refreshRequestDto);
            if (refreshRequestDto == null)
            {
                return Unauthorized("Refresh Token Expired");
            }

            return Ok(refreshTokenModel); 

        }
    }
}