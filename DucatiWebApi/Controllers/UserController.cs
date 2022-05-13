using DucatiWebApi.Data;
using Microsoft.AspNetCore.Mvc;

namespace DucatiWebApi.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly DucatiWebApiContext _context;

        public UserController(DucatiWebApiContext context)
        {
            _context = context;
        }

        //GET: api/users = gets user with same username
        [HttpGet("/api/users/{username}")]
        public async Task<ActionResult<UserController>> GetUser(string username)
        {
            var user = await _context.Users.FindAsync(username);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }
    }
}
