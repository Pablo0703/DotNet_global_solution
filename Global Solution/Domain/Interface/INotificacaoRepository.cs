    using global::Global_Solution.Domain.Entities;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    namespace Global_Solution.Domain.Interfaces
    {
        public interface INotificacaoRepository
        {
            Task<IEnumerable<NotificacaoEntity>> GetAllAsync();
            Task<NotificacaoEntity> GetByIdAsync(int id);
            Task<NotificacaoEntity> AddAsync(NotificacaoEntity entity);
            Task<NotificacaoEntity> UpdateAsync(NotificacaoEntity entity);
            Task<bool> DeleteAsync(int id);
        }
    }

