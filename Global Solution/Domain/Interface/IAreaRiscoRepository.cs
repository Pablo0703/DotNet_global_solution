    using global::Global_Solution.Domain.Entities;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    namespace Global_Solution.Domain.Interfaces
    {
        public interface IAreaRiscoRepository
        {
            Task<IEnumerable<AreaRiscoEntity>> GetAllAsync();
            Task<AreaRiscoEntity> GetByIdAsync(int id);
            Task<AreaRiscoEntity> AddAsync(AreaRiscoEntity entity);
            Task<AreaRiscoEntity> UpdateAsync(AreaRiscoEntity entity);
            Task<bool> DeleteAsync(int id);
        }
    }

