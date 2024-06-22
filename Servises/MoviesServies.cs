using FirstProj.Models;
using Microsoft.EntityFrameworkCore;

namespace FirstProj.Servises
{
    
    public class MoviesServies : IMoviesServies
    {
        private readonly Dbconmovi dbconmov;
        public MoviesServies(Dbconmovi _dbconmov)
        {
            dbconmov = _dbconmov;
        }
        public async Task<IEnumerable<Movie>> GetAll(byte genreid = 0)
        {
            var mov= await dbconmov.movies.Where(m=>m.GenreId==genreid||genreid==0).Include(g => g.genre).ToListAsync();
            return mov;
        }

        public async Task<Movie> GetById(int id)
        {
           return await dbconmov.movies.SingleOrDefaultAsync(g => g.Id == id);
        }

        public async Task<Movie> create(Movie add)
        {
            await dbconmov.AddAsync(add);
            dbconmov.SaveChanges();
            return add;
        }

        public Movie update(Movie movie)
        {
            dbconmov.Update(movie);
            dbconmov.SaveChanges();
            return movie;
        }

        
    }
}
