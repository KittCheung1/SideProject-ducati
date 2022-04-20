#nullable disable
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DucatiWebApi.Data
{
    public class DucatiWebApiContext : DbContext
    {
        public DucatiWebApiContext(DbContextOptions<DucatiWebApiContext> options)
            : base(options)
        {
        }

        public DbSet<DucatiWebApi.Model.Motorcycle> Motorcycle { get; set; }


        public class ApplicationDbContext : IdentityDbContext<IdentityUser, IdentityRole, string>
        {
            public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
            {
            }
        }
    }
}
