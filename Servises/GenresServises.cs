using FirstProj.Models;
using Microsoft.EntityFrameworkCore;

namespace FirstProj.Servises
{
 
    public class GenresServises : IGenerServise
    {
        private readonly Dbconmovi mov;
        public GenresServises(Dbconmovi _dbconmov)
        {
            mov = _dbconmov;
        }
        public async Task<Genre> Add(Genre genr)
        {
            await mov.AddAsync(genr);
            mov.SaveChanges();
            return genr;
        }

        public Genre Delete(Genre genr)
        {
            mov.Remove(genr);
            mov.SaveChanges() ;
            return genr;
        }

        public async Task<IEnumerable<Genre>> GetAll()
        {
            return await mov.Genres.OrderBy(g => g.name).ToListAsync();
        }

        public async Task<Genre> GetById(byte id)
        {
            return await mov.Genres.SingleOrDefaultAsync(g => g.id == id);
        }

        public async Task<bool> isvaliedgenre(byte id)
        {
           return await mov.Genres.AnyAsync(g => g.id == id);
        }

        public Genre Update(Genre genr)
        {
            mov.Update(genr);
            mov.SaveChanges();
            return genr;
        }

        

        
    }
}
