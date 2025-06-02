using Global_Solution.Application.Dtos;
using Global_Solution.Application.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Global_Solution.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly IUsuarioApplication _usuarioApp;

        public UsuarioController(IUsuarioApplication usuarioApp)
        {
            _usuarioApp = usuarioApp;
        }

        // GET: /Usuario
        public async Task<IActionResult> Index()
        {
            var usuarios = await _usuarioApp.GetAllAsync();
            return View(usuarios);
        }

        // GET: /Usuario/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var usuario = await _usuarioApp.GetByIdAsync(id);
            if (usuario == null) return NotFound();
            return View(usuario);
        }

        
        public IActionResult Create()
        {
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(UsuarioDto dto)
        {
            if (!ModelState.IsValid) return View(dto);

            await _usuarioApp.AddAsync(dto);
            return RedirectToAction(nameof(Index));
        }

        // GET: /Usuario/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var usuario = await _usuarioApp.GetByIdAsync(id);
            if (usuario == null) return NotFound();
            return View(usuario);
        }

        // POST: /Usuario/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, UsuarioDto dto)
        {
            if (id != dto.ID_USUARIO) return NotFound();
            if (!ModelState.IsValid) return View(dto);

            await _usuarioApp.UpdateAsync(id, dto);
            return RedirectToAction(nameof(Index));
        }


        // GET: /Usuario/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var usuario = await _usuarioApp.GetByIdAsync(id);
            if (usuario == null) return NotFound();
            return View(usuario);
        }

        // POST: /Usuario/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _usuarioApp.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
