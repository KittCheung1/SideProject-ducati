using DucatiWebApi.Model;
using Microsoft.AspNetCore.Identity;

namespace DucatiWebApi.User
{
    public class User : IdentityUser<long>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public Motorcycle Motorcycle { get; set; }
    }

}
