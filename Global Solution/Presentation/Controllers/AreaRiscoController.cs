using Global_Solution.Application.Dtos;
using Global_Solution.Application.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Global_Solution.Controllers
{
    public class AreaRiscoController : Controller
    {
        private readonly IAreaRiscoApplication _areaApp;

        public AreaRiscoController(IAreaRiscoApplication areaApp)
        {
            _areaApp = areaApp;
        }

        public async Task<IActionResult> Index()
        {
            var areas = await _areaApp.GetAllAsync();
            return View(areas);
        }

        public async Task<IActionResult> Details(int id)
        {
            var area = await _areaApp.GetByIdAsync(id);
            if (area == null) return NotFound();
            return View(area);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AreaRiscoDto dto)
        {
            if (!ModelState.IsValid) return View(dto);

            await _areaApp.AddAsync(dto);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var area = await _areaApp.GetByIdAsync(id);
            if (area == null) return NotFound();
            return View(area);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, AreaRiscoDto dto)
        {
            if (!ModelState.IsValid) return View(dto);

            await _areaApp.UpdateAsync(id, dto);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            var area = await _areaApp.GetByIdAsync(id);
            if (area == null) return NotFound();
            return View(area);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _areaApp.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
