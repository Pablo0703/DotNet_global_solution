using System.Collections.Generic;
using System.Threading.Tasks;
using Global_Solution.Application.Dtos;

namespace Global_Solution.Application.Interface
{
    public interface INotificacaoApplication
    {
        Task<IEnumerable<NotificacaoDto>> GetAllAsync();
        Task<NotificacaoDto> GetByIdAsync(int id);
        Task<NotificacaoDto> AddAsync(NotificacaoDto dto);
        Task<NotificacaoDto> UpdateAsync(int id, NotificacaoDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
