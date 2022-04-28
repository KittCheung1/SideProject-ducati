using Microsoft.AspNetCore.Identity;

namespace DucatiWebApi.Model
{
    public class Role : IdentityRole<long>

    {
        public const string Admin = "admin";
        public const string User = "user";
    }
}
