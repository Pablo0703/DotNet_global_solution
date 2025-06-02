using Global_Solution.Domain.Entities;
using Global_Solution.Domain.Interface;
using Global_Solution.Infrastructure.Data.AppData;
using Microsoft.EntityFrameworkCore;

namespace Global_Solution.Infrastructure.Data.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly ApplicationDbContext _context;

        public UsuarioRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<UsuarioEntity>> GetAllAsync()
        {
            return await _context.USUARIO.ToListAsync();
        }

        public async Task<UsuarioEntity> GetByIdAsync(int id)
        {
            return await _context.USUARIO.FindAsync(id);
        }

        public async Task<UsuarioEntity> AddAsync(UsuarioEntity entity)
        {
            _context.USUARIO.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<UsuarioEntity> UpdateAsync(int id, UsuarioEntity entity)
        {
            _context.USUARIO.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }


        public async Task<bool> DeleteAsync(int id)
        {
            var usuario = await _context.USUARIO
                .Include(u => u.INSCRICOES)
                .Include(u => u.NOTIFICACOES)
                .FirstOrDefaultAsync(u => u.ID_USUARIO == id);

            if (usuario == null) return false;

            _context.NOTIFICACAO.RemoveRange(usuario.NOTIFICACOES);
            _context.INSCRICAO_ALERTA.RemoveRange(usuario.INSCRICOES);

            _context.USUARIO.Remove(usuario);

            await _context.SaveChangesAsync();
            return true;
        }

    }
}
