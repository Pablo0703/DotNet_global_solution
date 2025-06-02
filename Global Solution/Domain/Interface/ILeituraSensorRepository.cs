    using global::Global_Solution.Domain.Entities;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    namespace Global_Solution.Domain.Interfaces
    {
        public interface ILeituraSensorRepository
        {
            Task<IEnumerable<LeituraSensorEntity>> GetAllAsync();
            Task<LeituraSensorEntity> GetByIdAsync(int id);
            Task<LeituraSensorEntity> AddAsync(LeituraSensorEntity entity);
            Task<LeituraSensorEntity> UpdateAsync(LeituraSensorEntity entity);
            Task<bool> DeleteAsync(int id);
        }
    }


