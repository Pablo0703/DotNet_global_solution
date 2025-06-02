    using global::Global_Solution.Domain.Entities;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    namespace Global_Solution.Domain.Interfaces
    {
        public interface IInscricaoAlertaRepository
        {
            Task<IEnumerable<InscricaoAlertaEntity>> GetAllAsync();
            Task<InscricaoAlertaEntity> GetByIdAsync(int id);
            Task<InscricaoAlertaEntity> AddAsync(InscricaoAlertaEntity entity);
            Task<InscricaoAlertaEntity> UpdateAsync(InscricaoAlertaEntity entity);
            Task<bool> DeleteAsync(int id);
        }
    }

