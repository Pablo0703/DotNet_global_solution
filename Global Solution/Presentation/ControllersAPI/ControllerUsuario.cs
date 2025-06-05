using Global_Solution.Application.Dtos;
using Global_Solution.Application.Interface;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class ControllerUsuario : ControllerBase
{
    private readonly IUsuarioApplication _service;

    public ControllerUsuario(IUsuarioApplication service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> Get() => Ok(await _service.GetAllAsync());

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var usuario = await _service.GetByIdAsync(id);
        return usuario == null ? NotFound() : Ok(usuario);
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] UsuarioDto dto)
    {
        var created = await _service.AddAsync(dto);
        return CreatedAtAction(nameof(GetById), new { id = created.ID_USUARIO }, created);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, [FromBody] UsuarioDto dto)
    {
        var updated = await _service.UpdateAsync(id, dto);
        return updated == null ? NotFound() : Ok(updated);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _service.DeleteAsync(id);
        return result ? NoContent() : NotFound();
    }
}
