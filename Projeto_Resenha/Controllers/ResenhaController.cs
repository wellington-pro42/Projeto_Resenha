using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Projeto_Resenha.Dominio1;
using ProjetoResenha.Data;
using ProjetoResenha.Models;

namespace ProjetoResenha.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ResenhaController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ResenhaController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var lista = await _context.Resenhas
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
                .Include(r => r.Usuario)
                .Include(r => r.Livro)
                .ThenInclude(l => l.Autor)
                .FirstOrDefaultAsync(r => r.getPkId_resenha() == id);

            if (resenha == null) return NotFound();

            return Ok(resenha);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Resenha resenha)
        {
            _context.Resenhas.Add(resenha);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = resenha.getPkId_resenha() }, resenha);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Resenha request)
        {
            var resenha = await _context.Resenhas.FindAsync(id);
            if (resenha == null) return NotFound();

            resenha.setFkId_usuario(request.getFkId_usuario());
            resenha.setFkId_livro(request.getFkId_livro());
            resenha.setTitulo(request.getTitulo());
            resenha.setResenha(request.getResenha());

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
