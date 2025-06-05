using Global_Solution.Domain.Entities;
using Global_Solution.Domain.Interfaces;
using Global_Solution.Infrastructure.Data.AppData;
using Microsoft.EntityFrameworkCore;


namespace Global_Solution.Infrastructure.Data.Repositories
{
    public class AreaRiscoRepository : IAreaRiscoRepository
    {
        private readonly ApplicationDbContext _context;

        public AreaRiscoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<AreaRiscoEntity>> GetAllAsync()
        {
            return await _context.AREA_RISCO.ToListAsync();
        }

        public async Task<AreaRiscoEntity> GetByIdAsync(int id)
        {
            return await _context.AREA_RISCO.FindAsync(id);
        }

        public async Task<AreaRiscoEntity> AddAsync(AreaRiscoEntity entity)
        {
            _context.AREA_RISCO.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<AreaRiscoEntity> UpdateAsync(AreaRiscoEntity entity)
        {
            _context.AREA_RISCO.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _context.AREA_RISCO.FindAsync(id);
            if (entity == null) return false;

            _context.AREA_RISCO.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
