using Global_Solution.Domain.Entities;
using Global_Solution.Domain.Interface;
using Global_Solution.Infrastructure.Data.AppData;
using Microsoft.EntityFrameworkCore;

namespace Global_Solution.Infrastructure.Data.Repositories
{
    public class SensorRepository : ISensorRepository
    {
        private readonly ApplicationDbContext _context;

        public SensorRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<SensorEntity>> GetAllAsync()
        {
            return await _context.SENSOR.ToListAsync();
        }

        public async Task<SensorEntity> GetByIdAsync(string id)
        {
            return await _context.SENSOR.FindAsync(id);
        }

        public async Task<SensorEntity> AddAsync(SensorEntity entity)
        {
            _context.SENSOR.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<SensorEntity> UpdateAsync(SensorEntity entity)
        {
            _context.SENSOR.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> DeleteAsync(string id)
        {
            var entity = await _context.SENSOR.FindAsync(id);
            if (entity == null) return false;

            _context.SENSOR.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
