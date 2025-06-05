using System.Collections.Generic;
using System.Threading.Tasks;
using Global_Solution.Application.Dtos;

namespace Global_Solution.Application.Interface
{
    public interface IAlertaApplication
    {
        Task<IEnumerable<AlertaDto>> GetAllAsync();
        Task<AlertaDto> GetByIdAsync(int id);
        Task<AlertaDto> AddAsync(AlertaDto dto);
        Task<AlertaDto> UpdateAsync(int id, AlertaDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
