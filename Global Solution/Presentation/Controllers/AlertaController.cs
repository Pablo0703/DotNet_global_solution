using Global_Solution.Application.Dtos;
using Global_Solution.Application.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Global_Solution.Controllers
{
    public class AlertaController : Controller
    {
        private readonly IAlertaApplication _alertaApp;

        public AlertaController(IAlertaApplication alertaApp)
        {
            _alertaApp = alertaApp;
        }

        public async Task<IActionResult> Index()
        {
            var alertas = await _alertaApp.GetAllAsync();
            return View(alertas);
        }

        public async Task<IActionResult> Details(int id)
        {
            var alerta = await _alertaApp.GetByIdAsync(id);
            if (alerta == null) return NotFound();
            return View(alerta);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AlertaDto dto)
        {
            if (!ModelState.IsValid) return View(dto);

            await _alertaApp.AddAsync(dto);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var alerta = await _alertaApp.GetByIdAsync(id);
            if (alerta == null) return NotFound();
            return View(alerta);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, AlertaDto dto)
        {
            if (!ModelState.IsValid) return View(dto);

            await _alertaApp.UpdateAsync(id, dto);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            var alerta = await _alertaApp.GetByIdAsync(id);
            if (alerta == null) return NotFound();
            return View(alerta);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _alertaApp.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
