using DucatiWebApi.DTO;
using DucatiWebApi.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

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

        [HttpPost("/auth/refreshToken")]
        public LoginResponseDTO RefreshToken()
        {
            var cookie = HttpContext.Request.Cookies[RefreshTokenCookieKey];
            if (cookie != null)
            {
                var user = this._userManager.Users.FirstOrDefault(user => user.SecurityStamp == cookie);
                if (user != null)
                {
                    var jwtToken = CreateJWT(user);
                    return new LoginResponseDTO(true, jwtToken);
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
        private static void AppendRefreshTokenCookie(User user, IResponseCookies cookies)
        {
            var options = new CookieOptions();
            options.HttpOnly = true;
            options.Secure = true;
            options.SameSite = SameSiteMode.Strict;
            options.Expires = DateTime.Now.AddMinutes(60);
            cookies.Append(RefreshTokenCookieKey, user.SecurityStamp, options);
        }

        private static string CreateJWT(User user)
        {
            var secretkey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("secretKey"));
            var credentials = new SigningCredentials(secretkey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
        new Claim(ClaimTypes.Name, user.UserName), // NOTE: this will be the "User.Identity.Name" value
        new Claim(JwtRegisteredClaimNames.Email, user.Email),
        new Claim(JwtRegisteredClaimNames.Jti, user.Id.ToString()),
    };

            var token = new JwtSecurityToken(
                issuer: "Jwt:Issuer",
                audience: "Jwt:Audience",
                claims: claims,
                expires: DateTime.Now.AddMinutes(60),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
