using System.Collections.Generic;
using System.Threading.Tasks;
using Global_Solution.Application.Dtos;

namespace Global_Solution.Application.Interface
{
    public interface IAreaRiscoApplication
    {
        Task<IEnumerable<AreaRiscoDto>> GetAllAsync();
        Task<AreaRiscoDto> GetByIdAsync(int id);
        Task<AreaRiscoDto> AddAsync(AreaRiscoDto dto);
        Task<AreaRiscoDto> UpdateAsync(int id,AreaRiscoDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
