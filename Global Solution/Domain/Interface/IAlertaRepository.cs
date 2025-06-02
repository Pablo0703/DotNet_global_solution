using Global_Solution.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Global_Solution.Domain.Interfaces
{
    public interface IAlertaRepository
    {
        Task<IEnumerable<AlertaEntity>> GetAllAsync();
        Task<AlertaEntity> GetByIdAsync(int id);
        Task<AlertaEntity> AddAsync(AlertaEntity entity);
        Task<AlertaEntity> UpdateAsync(AlertaEntity entity);
        Task<bool> DeleteAsync(int id);
    }
}
