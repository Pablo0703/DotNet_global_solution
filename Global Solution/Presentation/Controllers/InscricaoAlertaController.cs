using Global_Solution.Application.Dtos;
using Global_Solution.Application.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Global_Solution.Controllers
{
    public class InscricaoAlertaController : Controller
    {
        private readonly IInscricaoAlertaApplication _inscricaoApp;

        public InscricaoAlertaController(IInscricaoAlertaApplication inscricaoApp)
        {
            _inscricaoApp = inscricaoApp;
        }

        public async Task<IActionResult> Index()
        {
            var inscricoes = await _inscricaoApp.GetAllAsync();
            return View(inscricoes);
        }

        public async Task<IActionResult> Details(int id)
        {
            var inscricao = await _inscricaoApp.GetByIdAsync(id);
            if (inscricao == null) return NotFound();
            return View(inscricao);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(InscricaoAlertaDto dto)
        {
            if (!ModelState.IsValid)
            {
                foreach (var e in ModelState)
                {
                    Console.WriteLine($"Erro no campo {e.Key}: {string.Join(", ", e.Value.Errors.Select(er => er.ErrorMessage))}");
                }
                return View(dto);
            }

            await _inscricaoApp.AddAsync(dto);
            return RedirectToAction(nameof(Index));
        }


        public async Task<IActionResult> Edit(int id)
        {
            var inscricao = await _inscricaoApp.GetByIdAsync(id);
            if (inscricao == null) return NotFound();
            return View(inscricao);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, InscricaoAlertaDto dto)
        {
            if (!ModelState.IsValid) return View(dto);

            await _inscricaoApp.UpdateAsync(id, dto);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            var inscricao = await _inscricaoApp.GetByIdAsync(id);
            if (inscricao == null) return NotFound();
            return View(inscricao);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _inscricaoApp.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
