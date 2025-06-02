using Global_Solution.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Global_Solution.Domain.Interface
{
    public interface IUsuarioRepository
    {
        Task<IEnumerable<UsuarioEntity>> GetAllAsync();
        Task<UsuarioEntity> GetByIdAsync(int id);
        Task<UsuarioEntity> AddAsync(UsuarioEntity entity);
        Task<UsuarioEntity> UpdateAsync(int id, UsuarioEntity entity);
        Task<bool> DeleteAsync(int id);
    }
}
