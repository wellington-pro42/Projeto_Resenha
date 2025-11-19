using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Projeto_Resenha.Dominio1;
using ProjetoResenha.Data;

namespace ProjetoResenha.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ResenhaController : ControllerBase
    {
        private readonly AppDbContext _context;
        public ResenhaController(AppDbContext context) => _context = context;

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var lista = await _context.Resenhas
                .AsNoTracking()
                .Include(r => r.Usuario)
                .Include(r => r.Livro)
                    .ThenInclude(l => l.Autor)
                .ToListAsync();
            return Ok(lista);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var resenha = await _context.Resenhas
                .AsNoTracking()
                .Include(r => r.Usuario)
                .Include(r => r.Livro)
                    .ThenInclude(l => l.Autor)
                .FirstOrDefaultAsync(r => r.pkid_resenha_prop == id);

            if (resenha == null) return NotFound();
            return Ok(resenha);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Resenha resenha)
        {
            
            if (resenha.pkid_resenha_prop == 0 && resenha.conteudo_prop != null && resenha.Usuario == null)
            {
                
            }

            _context.Resenhas.Add(resenha);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = resenha.pkid_resenha_prop }, resenha);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Resenha request)
        {
            var resenha = await _context.Resenhas.FindAsync(id);
            if (resenha == null) return NotFound();

            resenha.fk_usuario_prop = request.fk_usuario_prop;
            resenha.fk_livro_prop = request.fk_livro_prop;
            resenha.titulo_prop = request.titulo_prop;
            resenha.conteudo_prop = request.conteudo_prop;

            await _context.SaveChangesAsync();
            return Ok(resenha);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var resenha = await _context.Resenhas.FindAsync(id);
            if (resenha == null) return NotFound();

            _context.Resenhas.Remove(resenha);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
