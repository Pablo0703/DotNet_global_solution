using Global_Solution.Application.Dtos;
using Global_Solution.Application.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Global_Solution.Controllers
{
    public class SensorController : Controller
    {
        private readonly ISensorApplication _sensorApp;

        public SensorController(ISensorApplication sensorApp)
        {
            _sensorApp = sensorApp;
        }

        public async Task<IActionResult> Index()
        {
            var sensores = await _sensorApp.GetAllAsync();
            return View(sensores);
        }

        public async Task<IActionResult> Details(string id)
        {
            var sensor = await _sensorApp.GetByIdAsync(id);
            if (sensor == null) return NotFound();
            return View(sensor);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SensorDto dto)
        {
            if (!ModelState.IsValid) return View(dto);

            await _sensorApp.AddAsync(dto);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(string id)
        {
            var sensor = await _sensorApp.GetByIdAsync(id);
            if (sensor == null) return NotFound();
            return View(sensor);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, SensorDto dto)
        {
            if (!ModelState.IsValid) return View(dto);

            await _sensorApp.UpdateAsync(id, dto);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(string id)
        {
            var sensor = await _sensorApp.GetByIdAsync(id);
            if (sensor == null) return NotFound();
            return View(sensor);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            await _sensorApp.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
