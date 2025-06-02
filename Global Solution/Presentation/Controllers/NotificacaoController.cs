using Global_Solution.Application.Dtos;
using Global_Solution.Application.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Global_Solution.Controllers
{
    public class NotificacaoController : Controller
    {
        private readonly INotificacaoApplication _notificacaoApp;

        public NotificacaoController(INotificacaoApplication notificacaoApp)
        {
            _notificacaoApp = notificacaoApp;
        }

        public async Task<IActionResult> Index()
        {
            var notificacoes = await _notificacaoApp.GetAllAsync();
            return View(notificacoes);
        }

        public async Task<IActionResult> Details(int id)
        {
            var notificacao = await _notificacaoApp.GetByIdAsync(id);
            if (notificacao == null) return NotFound();
            return View(notificacao);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(NotificacaoDto dto)
        {
            if (!ModelState.IsValid) return View(dto);

            await _notificacaoApp.AddAsync(dto);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var notificacao = await _notificacaoApp.GetByIdAsync(id);
            if (notificacao == null) return NotFound();
            return View(notificacao);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, NotificacaoDto dto)
        {
            if (!ModelState.IsValid) return View(dto);

            await _notificacaoApp.UpdateAsync(id, dto);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            var notificacao = await _notificacaoApp.GetByIdAsync(id);
            if (notificacao == null) return NotFound();
            return View(notificacao);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _notificacaoApp.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
