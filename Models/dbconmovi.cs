using Microsoft.EntityFrameworkCore;

namespace FirstProj.Models
{
    public class Dbconmovi : DbContext
    {
        public Dbconmovi(DbContextOptions<Dbconmovi> options):base (options)
        {
        }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Movie> movies { get; set; }
    }
}
