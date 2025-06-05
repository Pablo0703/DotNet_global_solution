using Global_Solution.Application.Dtos;
using Global_Solution.Application.Interface;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class ControllerAreaRisco : ControllerBase
{
    private readonly IAreaRiscoApplication _service;

    public ControllerAreaRisco(IAreaRiscoApplication service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> Get() => Ok(await _service.GetAllAsync());

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var area = await _service.GetByIdAsync(id);
        return area == null ? NotFound() : Ok(area);
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] AreaRiscoDto dto)
    {
        var created = await _service.AddAsync(dto);
        return CreatedAtAction(nameof(GetById), new { id = created.ID_AREA }, created);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, [FromBody] AreaRiscoDto dto)
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
