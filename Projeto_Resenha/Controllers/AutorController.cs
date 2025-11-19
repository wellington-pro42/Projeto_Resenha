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

        public AutorController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _context.Autores.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var autor = await _context.Autores.FindAsync(id);
            if (autor == null) return NotFound();
            return Ok(autor);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Autor autor)
        {
            _context.Autores.Add(autor);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = autor.getPkid_autor() }, autor);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Autor request)
        {
            var autor = await _context.Autores.FindAsync(id);
            if (autor == null) return NotFound();

            autor.setNome(request.getNome());
            autor.setNacionalidade(request.getNacionalidade());
            autor.setData_nascimento(request.GetDateTime());

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
