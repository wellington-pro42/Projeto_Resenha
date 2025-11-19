using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Projeto_Resenha.Dominio1;
using ProjetoResenha.Data;

namespace ProjetoResenha.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LivroController : ControllerBase
    {
        private readonly AppDbContext _context;
        public LivroController(AppDbContext context) => _context = context;

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var livros = await _context.Livros
                .AsNoTracking()
                .Include(l => l.Autor)
                .ToListAsync();
            return Ok(livros);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var livro = await _context.Livros
                .AsNoTracking()
                .Include(l => l.Autor)
                .FirstOrDefaultAsync(l => l.pkid_livro_prop == id);

            if (livro == null) return NotFound();
            return Ok(livro);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Livro livro)
        {
            _context.Livros.Add(livro);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = livro.pkid_livro_prop }, livro);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Livro request)
        {
            var livro = await _context.Livros.FindAsync(id);
            if (livro == null) return NotFound();

            livro.titulo_prop = request.titulo_prop;
            livro.genero_prop = request.genero_prop;
            livro.fkId_autor_prop = request.fkId_autor_prop;
            livro.ano_publicacao_prop = request.ano_publicacao_prop;

            await _context.SaveChangesAsync();
            return Ok(livro);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var livro = await _context.Livros.FindAsync(id);
            if (livro == null) return NotFound();

            _context.Livros.Remove(livro);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
