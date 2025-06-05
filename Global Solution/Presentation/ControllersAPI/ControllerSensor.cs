using Global_Solution.Application.Dtos;
using Global_Solution.Application.Interface;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class ControllerSensor : ControllerBase
{
    private readonly ISensorApplication _service;

    public ControllerSensor(ISensorApplication service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> Get() => Ok(await _service.GetAllAsync());

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(string id)
    {
        var sensor = await _service.GetByIdAsync(id);
        return sensor == null ? NotFound() : Ok(sensor);
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] SensorDto dto)
    {
        var created = await _service.AddAsync(dto);
        return CreatedAtAction(nameof(GetById), new { id = created.ID_SENSOR }, created);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(string id, [FromBody] SensorDto dto)
    {
        var updated = await _service.UpdateAsync(id, dto);
        return updated == null ? NotFound() : Ok(updated);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(string id)
    {
        var result = await _service.DeleteAsync(id);
        return result ? NoContent() : NotFound();
    }
}
