using FirstProj.Models;

namespace FirstProj.Servises
{
    public interface IGenerServise
    {
        Task<IEnumerable<Genre>> GetAll();
        Task<Genre> GetById(byte id);
        Task<Genre> Add(Genre genre);
        Genre Update(Genre genre);
        Genre Delete(Genre genre);
        Task<bool> isvaliedgenre(byte id);
    }
}
