using System.Collections.Generic;
using System.Threading.Tasks;
using Global_Solution.Application.Dtos;

namespace Global_Solution.Application.Interface
{
    public interface IInscricaoAlertaApplication
    {
        Task<IEnumerable<InscricaoAlertaDto>> GetAllAsync();
        Task<InscricaoAlertaDto> GetByIdAsync(int id);
        Task<InscricaoAlertaDto> AddAsync(InscricaoAlertaDto dto);
        Task<InscricaoAlertaDto> UpdateAsync(int id, InscricaoAlertaDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
