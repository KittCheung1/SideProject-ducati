using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace DucatiWebApi.Model
{
    [ApiController]
    public class AuthController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public AuthController(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            this._userManager = userManager;
            this._signInManager = signInManager;
        }
    }
}
