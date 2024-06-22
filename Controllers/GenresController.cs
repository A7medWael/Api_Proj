using FirstProj.Models;
using FirstProj.Servises;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FirstProj.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenresController : ControllerBase
    {
        private readonly IGenerServise _iGenerServise;
        public GenresController(IGenerServise iGenerServise)
        {
            _iGenerServise = iGenerServise;
        }

        [HttpGet]
        public async Task<IActionResult> show()
        {
            var gen = await _iGenerServise.GetAll();
            return Ok(gen);
        }
        [HttpPost]
        public async Task<IActionResult> addgen(AddGen addGen)
        {
            var genr=new Genre { name = addGen.Name };
            await _iGenerServise.Add(genr);
            return Ok(genr);
        }
        [HttpDelete]
        public async Task<IActionResult> delname(byte Id)
        {
            var delgen = await _iGenerServise.GetById(Id);
           _iGenerServise.Delete(delgen);
            return Ok(delgen);

        }
        [HttpPut("{id}")]
        public async Task<IActionResult> edit(byte id, [FromBody] AddGen gen)
        {
            var updategen = await _iGenerServise.GetById(id);
            if (updategen == null)
            {
                return NotFound("No Genre Yet");
            }
            else
            {
                updategen.name = gen.Name;
                _iGenerServise.Update(updategen);
                return Ok(updategen);
            }
        }
    }
}
