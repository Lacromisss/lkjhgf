using Microsoft.EntityFrameworkCore;
using WebApplication4.Model;

namespace WebApplication4.dAL
{
    public class AppDbConetxt:DbContext
    {
        public AppDbConetxt(DbContextOptions options):base(options)
        {

        }
        public DbSet<Human> humans { get; set; }

    }
}
