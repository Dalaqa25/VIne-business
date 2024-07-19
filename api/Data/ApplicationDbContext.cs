using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> dbContextOptions)
        :base(dbContextOptions)
        {
            
        }

       public DbSet<Grapes> Grapes {get; set;}
       public DbSet<Vines> Vines {get; set;}
    }
}