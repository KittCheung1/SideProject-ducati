using DucatiWebApi.DTO;
using DucatiWebApi.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace DucatiWebApi.Controllers
{
    [Route("auth/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public AuthController(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            this._userManager = userManager;
            this._signInManager = signInManager;
        }

        [HttpPost("/auth/register")]
        public async Task<ReadRegisterDTO> Register(CreateRegisterDTO request)
        {
            var user = new User()
            {
                UserName = request.UserName,
            };

            var result = await this._userManager.CreateAsync(user, request.Password);
            return new ReadRegisterDTO();
        }

        [HttpPost("/auth/login")]
        public async Task<LoginResponseDTO> Login(LoginRequestDTO request)
        {
            var user = await this._userManager.FindByNameAsync(request.UserName);
            if (user != null)
            {
                var signIn = await this._signInManager.CheckPasswordSignInAsync(user, request.Password, false);
                if (signIn.Succeeded)
                {
                    string jwt = CreateJWT(user);
                    AppendRefreshTokenCookie(user, HttpContext.Response.Cookies);

                    return new LoginResponseDTO(true, jwt);
                }
                else
                {
                    return LoginResponseDTO.Failed;
                }
            }
            else
            {
                return LoginResponseDTO.Failed;
            }
        }
    }
}
