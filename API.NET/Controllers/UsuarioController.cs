using API.NET.Data;
using API.NET.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Collections.Generic;

[Route("api/[controller]")]
[ApiController]
public class UsuarioController : ControllerBase
{
    private readonly AppDbContext _context;

    public UsuarioController(AppDbContext context)
    {
        _context = context;
    }

    // GET: api/usuario
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Usuario>>> Get()
    {
        var usuarios = await _context.Usuarios.ToListAsync();
        return Ok(usuarios);
    }

    // GET: api/usuario/{id}
    [HttpGet("{id}")]
    public async Task<ActionResult<Usuario>> GetById(int id)
    {
        var usuario = await _context.Usuarios.FindAsync(id);
        if (usuario == null)
            return NotFound(new { message = "Usuário não encontrado" });

        return Ok(usuario);
    }

    // POST: api/usuario
    [HttpPost]
    public async Task<ActionResult<Usuario>> Post([FromBody] Usuario usuario)
    {
        if (usuario == null)
            return BadRequest(new { message = "Dados inválidos" });

        _context.Usuarios.Add(usuario);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetById), new { id = usuario.Id }, usuario);
    }

    // PUT: api/usuario/{id}
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, [FromBody] Usuario usuario)
    {
        if (id != usuario.Id)
            return BadRequest(new { message = "ID inconsistente" });

        var usuarioExistente = await _context.Usuarios.FindAsync(id);
        if (usuarioExistente == null)
            return NotFound(new { message = "Usuário não encontrado" });

        _context.Entry(usuarioExistente).CurrentValues.SetValues(usuario);
        await _context.SaveChangesAsync();

        return NoContent(); // 204 - Atualização bem-sucedida sem retorno
    }

    // DELETE: api/usuario/{id}
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var usuario = await _context.Usuarios.FindAsync(id);
        if (usuario == null)
            return NotFound(new { message = "Usuário não encontrado" });

        _context.Usuarios.Remove(usuario);
        await _context.SaveChangesAsync();

        return Ok(new { message = "Usuário removido com sucesso" });
    }
}
