using Global_Solution.Application.Dtos;
using Global_Solution.Application.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Global_Solution.Presentation.ControllersAPI
{
    [ApiController]
    [Route("api/[controller]")]
    public class ControllerAlerta : ControllerBase
    {
        private readonly IAlertaApplication _alertaApp;

        public ControllerAlerta(IAlertaApplication alertaApp)
        {
            _alertaApp = alertaApp;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AlertaDto>>> GetAll()
        {
            var alertas = await _alertaApp.GetAllAsync();
            return Ok(alertas);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AlertaDto>> GetById(int id)
        {
            var alerta = await _alertaApp.GetByIdAsync(id);
            if (alerta == null) return NotFound();
            return Ok(alerta);
        }

        [HttpPost]
        public async Task<ActionResult<AlertaDto>> Create([FromBody] AlertaDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var created = await _alertaApp.AddAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = created.ID_ALERTA }, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] AlertaDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var updated = await _alertaApp.UpdateAsync(id, dto);
            if (updated == null) return NotFound();
            return Ok(updated);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var success = await _alertaApp.DeleteAsync(id);
            if (!success) return NotFound();
            return NoContent();
        }
    }
}
