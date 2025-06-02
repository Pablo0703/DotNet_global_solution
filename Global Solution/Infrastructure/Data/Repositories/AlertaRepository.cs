using Global_Solution.Domain.Entities;
using Global_Solution.Domain.Interfaces;
using Global_Solution.Infrastructure.Data.AppData;
using Microsoft.EntityFrameworkCore;


namespace Global_Solution.Infrastructure.Data.Repositories
{
    public class AlertaRepository : IAlertaRepository
    {
        private readonly ApplicationDbContext _context;

        public AlertaRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<AlertaEntity>> GetAllAsync()
        {
            return await _context.ALERTA.ToListAsync();
        }

        public async Task<AlertaEntity> GetByIdAsync(int id)
        {
            return await _context.ALERTA.FindAsync(id);
        }

        public async Task<AlertaEntity> AddAsync(AlertaEntity entity)
        {
            _context.ALERTA.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<AlertaEntity> UpdateAsync(AlertaEntity entity)
        {
            _context.ALERTA.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _context.ALERTA.FindAsync(id);
            if (entity == null) return false;

            _context.ALERTA.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }
    }

}
