using DucatiWebApi.Data;
using DucatiWebApi.Model;
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
        [HttpGet("/api/users/")]
        public async Task<ActionResult<UserController>> GetUser(string username)
        {
            var user = await _context.Users.FindAsync(username);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpPost("/api/users/{id}")]
        public async Task<ActionResult<User>> PostUser(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUser", new { id = user.Id }, user);
        }
    }
}
