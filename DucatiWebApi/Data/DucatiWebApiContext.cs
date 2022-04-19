#nullable disable
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

    }
}
