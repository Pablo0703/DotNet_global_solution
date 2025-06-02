using System.Collections.Generic;
using System.Threading.Tasks;
using Global_Solution.Application.Dtos;

namespace Global_Solution.Application.Interface
{
    public interface ISensorApplication
    {
        Task<IEnumerable<SensorDto>> GetAllAsync();
        Task<SensorDto> GetByIdAsync(string id);
        Task<SensorDto> AddAsync(SensorDto dto);
        Task<SensorDto> UpdateAsync(string id, SensorDto dto);
        Task<bool> DeleteAsync(string id);
    }
}
