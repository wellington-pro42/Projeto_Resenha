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

            public LivroController(AppDbContext context)
            {
                _context = context;
            }

            [HttpGet]
            public async Task<IActionResult> GetAll()
            {
                return Ok(await _context.Livros.Include(l => l.Autor).ToListAsync());
            }

            [HttpGet("{id}")]
            public async Task<IActionResult> GetById(int id)
            {
                var livro = await _context.Livros
                    .Include(l => l.Autor)
                    .FirstOrDefaultAsync(l => l.getPkId_livro() == id);

                if (livro == null) return NotFound();

                return Ok(livro);
            }

            [HttpPost]
            public async Task<IActionResult> Create(Livro livro)
            {
                _context.Livros.Add(livro);
                await _context.SaveChangesAsync();
                return CreatedAtAction(nameof(GetById), new { id = livro.getPkId_livro() }, livro);
            }

            [HttpPut("{id}")]
            public async Task<IActionResult> Update(int id, Livro request)
            {
                var livro = await _context.Livros.FindAsync(id);
                if (livro == null) return NotFound();

                livro.setTitulo(request.getTitulo());
                livro.setFkId_autor(request.getFkId_autor());
                livro.setAno_publicacao(request.getAno_publicacao());
                livro.setGenero(request.getGenero());

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
