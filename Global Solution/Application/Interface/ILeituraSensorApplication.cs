using System.Collections.Generic;
using System.Threading.Tasks;
using Global_Solution.Application.Dtos;

namespace Global_Solution.Application.Interface
{
    public interface ILeituraSensorApplication
    {
        Task<IEnumerable<LeituraSensorDto>> GetAllAsync();
        Task<LeituraSensorDto> GetByIdAsync(int id);
        Task<LeituraSensorDto> AddAsync(LeituraSensorDto dto);
        Task<LeituraSensorDto> UpdateAsync(int id,LeituraSensorDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
