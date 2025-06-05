using Global_Solution.Domain.Entities;
using Global_Solution.Domain.Interfaces;
using Global_Solution.Infrastructure.Data.AppData;
using Microsoft.EntityFrameworkCore;

namespace Global_Solution.Infrastructure.Data.Repositories
{
    public class LeituraSensorRepository : ILeituraSensorRepository
    {
        private readonly ApplicationDbContext _context;

        public LeituraSensorRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<LeituraSensorEntity>> GetAllAsync()
        {
            return await _context.LEITURA_SENSOR.ToListAsync();
        }

        public async Task<LeituraSensorEntity> GetByIdAsync(int id)
        {
            return await _context.LEITURA_SENSOR.FindAsync(id);
        }

        public async Task<LeituraSensorEntity> AddAsync(LeituraSensorEntity entity)
        {
            _context.LEITURA_SENSOR.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<LeituraSensorEntity> UpdateAsync(LeituraSensorEntity entity)
        {
            _context.LEITURA_SENSOR.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _context.LEITURA_SENSOR.FindAsync(id);
            if (entity == null) return false;

            _context.LEITURA_SENSOR.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
