using Microsoft.AspNetCore.Identity;

namespace DucatiWebApi.User
{
    public class User : IdentityUser<long>
    {
    }

    public class Role : IdentityRole<long>
    {
    }

}
