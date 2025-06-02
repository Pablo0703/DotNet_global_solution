using Global_Solution.Domain.Entities;
using Global_Solution.Domain.Interfaces;
using Global_Solution.Infrastructure.Data.AppData;
using Microsoft.EntityFrameworkCore;

namespace Global_Solution.Infrastructure.Data.Repositories
{
    public class NotificacaoRepository : INotificacaoRepository
    {
        private readonly ApplicationDbContext _context;

        public NotificacaoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<NotificacaoEntity>> GetAllAsync()
        {
            return await _context.NOTIFICACAO.ToListAsync();
        }

        public async Task<NotificacaoEntity> GetByIdAsync(int id)
        {
            return await _context.NOTIFICACAO.FindAsync(id);
        }

        public async Task<NotificacaoEntity> AddAsync(NotificacaoEntity entity)
        {
            _context.NOTIFICACAO.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<NotificacaoEntity> UpdateAsync(NotificacaoEntity entity)
        {
            _context.NOTIFICACAO.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _context.NOTIFICACAO.FindAsync(id);
            if (entity == null) return false;

            _context.NOTIFICACAO.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
