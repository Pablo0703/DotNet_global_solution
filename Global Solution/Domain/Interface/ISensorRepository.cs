using Global_Solution.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Global_Solution.Domain.Interface
{
    public interface ISensorRepository
    {
        Task<IEnumerable<SensorEntity>> GetAllAsync();
        Task<SensorEntity> GetByIdAsync(string id);
        Task<SensorEntity> AddAsync(SensorEntity entity);
        Task<SensorEntity> UpdateAsync(SensorEntity entity);
        Task<bool> DeleteAsync(string id);
    }
}
