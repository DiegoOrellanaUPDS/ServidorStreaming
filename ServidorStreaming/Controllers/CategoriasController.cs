using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ServidorStreaming.Data;
using ServidorStreaming.Models;

namespace ServidorStreaming.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoriasController : ControllerBase
{
    private readonly ServidorStreamingContext _context;

    public CategoriasController(ServidorStreamingContext context)
    {
        _context = context;
    }

    // GET: api/categorias
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Categoria>>> GetCategorias()
    {
        return await _context.Categorias
            .AsNoTracking()
            .OrderBy(c => c.Id)
            .ToListAsync();
    }

    // GET: api/categorias/1
    [HttpGet("{id:int}")]
    public async Task<ActionResult<Categoria>> GetCategoria(int id)
    {
        var categoria = await _context.Categorias.FindAsync(id);

        if (categoria == null)
            return NotFound();

        return categoria;
    }

    // POST: api/categorias
    [HttpPost]
    public async Task<ActionResult<Categoria>> PostCategoria(Categoria categoria)
    {
        categoria.Id = 0;

        _context.Categorias.Add(categoria);
        await _context.SaveChangesAsync();

        return CreatedAtAction(
            nameof(GetCategoria),
            new { id = categoria.Id },
            categoria);
    }

    // PUT: api/categorias/1
    [HttpPut("{id:int}")]
    public async Task<IActionResult> PutCategoria(int id, Categoria categoria)
    {
        if (id != categoria.Id)
            return BadRequest("Los ID no coinciden.");

        var existente = await _context.Categorias.FindAsync(id);

        if (existente == null)
            return NotFound();

        existente.Nombre = categoria.Nombre;
        existente.Descripcion = categoria.Descripcion;

        await _context.SaveChangesAsync();

        return NoContent();
    }

    // DELETE: api/categorias/1
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteCategoria(int id)
    {
        var categoria = await _context.Categorias.FindAsync(id);

        if (categoria == null)
            return NotFound();

        _context.Categorias.Remove(categoria);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}
