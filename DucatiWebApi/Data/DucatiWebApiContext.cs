#nullable disable
using DucatiWebApi.Model;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DucatiWebApi.Data;

public class DucatiWebApiContext : IdentityDbContext<User, Role, long>
{
    public DucatiWebApiContext(DbContextOptions options)
        : base(options)
    {
    }

    public DbSet<DucatiWebApi.Model.Motorcycle> Motorcycle { get; set; }

}
