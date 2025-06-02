using Global_Solution.Application.Dtos;
using Global_Solution.Application.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Global_Solution.Controllers
{
    public class LeituraSensorController : Controller
    {
        private readonly ILeituraSensorApplication _leituraApp;

        public LeituraSensorController(ILeituraSensorApplication leituraApp)
        {
            _leituraApp = leituraApp;
        }

        public async Task<IActionResult> Index()
        {
            var leituras = await _leituraApp.GetAllAsync();
            return View(leituras);
        }

        public async Task<IActionResult> Details(int id)
        {
            var leitura = await _leituraApp.GetByIdAsync(id);
            if (leitura == null) return NotFound();
            return View(leitura);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(LeituraSensorDto dto)
        {
            if (!ModelState.IsValid) return View(dto);

            await _leituraApp.AddAsync(dto);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var leitura = await _leituraApp.GetByIdAsync(id);
            if (leitura == null) return NotFound();
            return View(leitura);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, LeituraSensorDto dto)
        {
            if (!ModelState.IsValid) return View(dto);

            await _leituraApp.UpdateAsync(id, dto);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            var leitura = await _leituraApp.GetByIdAsync(id);
            if (leitura == null) return NotFound();
            return View(leitura);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _leituraApp.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
