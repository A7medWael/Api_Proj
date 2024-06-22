using FirstProj.Migrations;
using FirstProj.Models;

namespace FirstProj.Servises
{
    public interface IMoviesServies
    {
        Task<IEnumerable<Movie>>GetAll(byte genreid=0);
        Task<Movie> GetById(int id);
        Task<Movie> create(Movie add);
       Movie update(Movie movie);

    }
}
