#nullable disable
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DucatiWebApi.Model;

public class DucatiWebApiContext : IdentityDbContext<User, Role, long>
{
    public DucatiWebApiContext(DbContextOptions options)
        : base(options)
    {
    }

    public DbSet<DucatiWebApi.Model.Motorcycle> Motorcycle { get; set; }

}
