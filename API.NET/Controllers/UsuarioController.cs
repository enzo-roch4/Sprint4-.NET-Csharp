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

    // GET: api/usuario/buscar/{id}
     /// <summary>
    /// Obtém um usuário pelo ID.
    /// </summary>
    /// <param name="id">ID do usuário.</param>
    /// <returns>Retorna os dados do usuário.</returns>
    [HttpGet("/api/usuario/buscar/{id}")]
    public async Task<ActionResult<Usuario>> GetById(int id)
    {
        var usuario = await _context.Usuario.FindAsync(id);
        if (usuario == null)
            return NotFound(new { message = "Usuário não encontrado" });

        return Ok(usuario);
    }

    // POST: api/usuario/cadastrar
    /// <summary>
    /// Cadastra um usuário.
    /// </summary>
    /// <returns>Cadastra os dados do usuário.</returns>
    [HttpPost("/api/usuario/cadastrar/")]
    public async Task<ActionResult<Usuario>> Post([FromBody] Usuario usuario)
    {
        if (usuario == null)
            return BadRequest(new { message = "Dados inválidos" });

        _context.Usuario.Add(usuario);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetById), new { id = usuario.id }, usuario);
    }

    // PUT: api/usuario/atualizar/{id}
    /// <summary>
    /// Atualiza os dados de um usuário.
    /// </summary>
    /// <returns>Mensagem informando que o usuário foi atualizado.</returns>
    [HttpPut("/api/usuario/atualizar/{id}")]
    public async Task<IActionResult> Put(int id, [FromBody] Usuario usuario)
    {
        if (id != usuario.id)
            return BadRequest(new { message = "ID inconsistente" });

        var usuarioExistente = await _context.Usuario.FindAsync(id);
        if (usuarioExistente == null)
            return NotFound(new { message = "Usuário não encontrado" });

        _context.Entry(usuarioExistente).CurrentValues.SetValues(usuario);
        await _context.SaveChangesAsync();

        return NoContent(); // 204 - Atualização bem-sucedida sem retorno
    }

    // DELETE: api/usuario/apagar/{id}
    /// <summary>
    /// Exclui um usuário.
    /// </summary>
    /// <returns>Mensagem confirmando exclusão.</returns>
    [HttpDelete("/api/usuario/apagar/{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var usuario = await _context.Usuario.FindAsync(id);
        if (usuario == null)
            return NotFound(new { message = "Usuário não encontrado" });

        _context.Usuario.Remove(usuario);
        await _context.SaveChangesAsync();

        return Ok(new { message = "Usuário removido com sucesso" });
    }
}
