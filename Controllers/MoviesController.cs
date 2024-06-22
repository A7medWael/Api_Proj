using AutoMapper;
using FirstProj.Migrations;
using FirstProj.Models;
using FirstProj.Servises;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace FirstProj.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        //private new List<string> _allowextention = new List<string> { ".png", "jpg" };
        //private long _maxallowsize = 1045576;
        private readonly IMapper _mapper;
        private readonly IMoviesServies _moviesServies;
        private readonly IGenerServise _gen;


        public MoviesController(IMoviesServies moviesServies,IGenerServise generServise,IMapper mapper)
        {
            _moviesServies = moviesServies;
            _gen = generServise;
            _mapper = mapper;
        }

      

        [HttpGet]
        public async Task<IActionResult> getallmovi()
        {
            var mov = await _moviesServies.GetAll();
            var data = _mapper.Map<IEnumerable<MovieDetails>>(mov);
            //var mov = await dbconmov.movies.Include(g => g.genre).Select(g =>
            //    new MovieDetails
            //    {
            //        Title = g.Title,
            //        GenreId = g.GenreId,
            //        Poster = g.Poster,
            //        StoreLine = g.StoreLine,
            //        year = g.year,
            //        Rate = g.Rate,
            //        GenreName = g.genre.name

            //    }).ToListAsync();
           
            return Ok(data);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> getmovibyid(int id)
        {
            //var mov = await dbconmov.movies.Include(g=>g.genre).SingleOrDefaultAsync(g=>g.Id==id);
            var mov = await _moviesServies.GetById(id);

            var m = new MovieDetails
            {
                Title = mov.Title,
                GenreId = mov.GenreId,
                Poster = mov.Poster,
                StoreLine = mov.StoreLine,
                year = mov.year,
                Rate = mov.Rate,
                GenreName = mov.genre.name

            };


            return Ok(m);
        }

        [HttpPost]
        public async Task<IActionResult> CreateMovie([FromForm]AddMove ad)
        {
            //if (!_allowextention.Contains(Path.GetExtension(ad.Poster.FileName).ToLower()))
            //    return BadRequest("only .png and .jpg");
            //if (ad.Poster.Length > _maxallowsize)
            //    return BadRequest("this size not allowed");
            // var isvaliedss=await dbconmov.Genres.AnyAsync(g=>g.id==ad.GenreId);
            var isvaliedss =await _gen.isvaliedgenre(ad.GenreId);
            if (!isvaliedss)
                return BadRequest("not found");


            using var datastream=new MemoryStream();
            await ad.Poster.CopyToAsync(datastream);
            var movi = _mapper.Map<Movie>(ad);
            movi.Poster=datastream.ToArray();
            //var movi = new Movie
            //{
            //    Title = ad.Title,
            //    Rate = ad.Rate,
            //    GenreId = ad.GenreId,
            //    year=ad.year,
            //    StoreLine = ad.StoreLine,
            //    Poster=datastream.ToArray()
            //};
            await _moviesServies.create(movi);
            return Ok(movi);

        }
        [HttpPut("{id}")]
        public async Task<IActionResult> updatemovie(int id, [FromForm] AddMove addmov)
        {
            var mov = await _moviesServies.GetById(id);
            using var datastream = new MemoryStream();
            await addmov.Poster.CopyToAsync(datastream);
            mov.Poster = datastream.ToArray();

            mov.Title = addmov.Title;
            mov.GenreId = addmov.GenreId;
            mov.StoreLine = addmov.StoreLine;
            mov.year = addmov.year;
            mov.Rate = addmov.Rate;
             _moviesServies.update(mov);
        //mov.genre.name=addmov.g
        return Ok(mov);
        }
    }
}
