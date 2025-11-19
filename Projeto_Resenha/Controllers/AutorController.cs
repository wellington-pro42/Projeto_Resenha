using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Projeto_Resenha.Dominio1;
using ProjetoResenha.Data;

namespace ProjetoResenha.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AutorController : ControllerBase
    {
        private readonly AppDbContext _context;
        public AutorController(AppDbContext context) => _context = context;

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var autores = await _context.Autores
                .AsNoTracking()
                .ToListAsync();
            return Ok(autores);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var autor = await _context.Autores
                .AsNoTracking()
                .FirstOrDefaultAsync(a => a.pkid_autor_prop == id);

            if (autor == null) return NotFound();
            return Ok(autor);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Autor autor)
        {
            _context.Autores.Add(autor);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = autor.pkid_autor_prop }, autor);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Autor request)
        {
            var autor = await _context.Autores.FindAsync(id);
            if (autor == null) return NotFound();

            autor.nome_prop = request.nome_prop;
            autor.nacionalidade_prop = request.nacionalidade_prop;
            autor.data_nascimento_prop = request.data_nascimento_prop;

            await _context.SaveChangesAsync();
            return Ok(autor);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var autor = await _context.Autores.FindAsync(id);
            if (autor == null) return NotFound();

            _context.Autores.Remove(autor);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
