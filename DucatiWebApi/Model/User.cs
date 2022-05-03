using Microsoft.AspNetCore.Identity;

namespace DucatiWebApi.Model
{
    public class User : IdentityUser<long>
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }

}
