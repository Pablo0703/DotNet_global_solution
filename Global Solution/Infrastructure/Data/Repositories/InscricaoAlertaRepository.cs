using Global_Solution.Domain.Entities;
using Global_Solution.Domain.Interfaces;
using Global_Solution.Infrastructure.Data.AppData;
using Microsoft.EntityFrameworkCore;

namespace Global_Solution.Infrastructure.Data.Repositories
{
    public class InscricaoAlertaRepository : IInscricaoAlertaRepository
    {
        private readonly ApplicationDbContext _context;

        public InscricaoAlertaRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<InscricaoAlertaEntity>> GetAllAsync()
        {
            return await _context.INSCRICAO_ALERTA.ToListAsync();
        }

        public async Task<InscricaoAlertaEntity> GetByIdAsync(int id)
        {
            return await _context.INSCRICAO_ALERTA.FindAsync(id);
        }

        public async Task<InscricaoAlertaEntity> AddAsync(InscricaoAlertaEntity entity)
        {
            _context.INSCRICAO_ALERTA.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<InscricaoAlertaEntity> UpdateAsync(InscricaoAlertaEntity entity)
        {
            _context.INSCRICAO_ALERTA.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _context.INSCRICAO_ALERTA.FindAsync(id);
            if (entity == null) return false;

            _context.INSCRICAO_ALERTA.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
