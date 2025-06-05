using System.Collections.Generic;
using System.Threading.Tasks;
using Global_Solution.Application.Dtos;

namespace Global_Solution.Application.Interface
{
    public interface IUsuarioApplication
    {
        Task<IEnumerable<UsuarioDto>> GetAllAsync();
        Task<UsuarioDto> GetByIdAsync(int id);
        Task<UsuarioDto> AddAsync(UsuarioDto dto);
        Task<UsuarioDto> UpdateAsync(int id, UsuarioDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
