using Global_Solution.Application.Dtos;
using Global_Solution.Application.Interface;
using Global_Solution.Domain.Entities;
using Global_Solution.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Global_Solution.Application.Services
{
    public class LeituraSensorApplication : ILeituraSensorApplication
    {
        private readonly ILeituraSensorRepository _repository;

        public LeituraSensorApplication(ILeituraSensorRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<LeituraSensorDto>> GetAllAsync()
        {
            try
            {
                var leituras = await _repository.GetAllAsync();
                return leituras.Select(l => new LeituraSensorDto
                {
                    ID_LEITURA = l.ID_LEITURA,
                    ID_SENSOR = l.ID_SENSOR,
                    TIMESTAMP_LEITURA = l.TIMESTAMP_LEITURA,
                    VALOR_LEITURA = l.VALOR_LEITURA,
                    UNIDADE_MEDIDA = l.UNIDADE_MEDIDA
                });
            }
            catch
            {
                return null;
            }
        }

        public async Task<LeituraSensorDto> GetByIdAsync(int id)
        {
            try
            {
                var l = await _repository.GetByIdAsync(id);
                if (l == null) return null;

                return new LeituraSensorDto
                {
                    ID_LEITURA = l.ID_LEITURA,
                    ID_SENSOR = l.ID_SENSOR,
                    TIMESTAMP_LEITURA = l.TIMESTAMP_LEITURA,
                    VALOR_LEITURA = l.VALOR_LEITURA,
                    UNIDADE_MEDIDA = l.UNIDADE_MEDIDA
                };
            }
            catch
            {
                return null;
            }
        }

        public async Task<LeituraSensorDto> AddAsync(LeituraSensorDto dto)
        {
            try
            {
                var entity = new LeituraSensorEntity
                {
                    ID_SENSOR = dto.ID_SENSOR,
                    TIMESTAMP_LEITURA = dto.TIMESTAMP_LEITURA,
                    VALOR_LEITURA = dto.VALOR_LEITURA,
                    UNIDADE_MEDIDA = dto.UNIDADE_MEDIDA
                };

                var created = await _repository.AddAsync(entity);
                dto.ID_LEITURA = created.ID_LEITURA;
                return dto;
            }
            catch
            {
                return null;
            }
        }

        public async Task<LeituraSensorDto> UpdateAsync(int id, LeituraSensorDto dto)
        {
            try
            {
                var entity = await _repository.GetByIdAsync(dto.ID_LEITURA);
                if (entity == null) return null;

                entity.ID_SENSOR = dto.ID_SENSOR;
                entity.TIMESTAMP_LEITURA = dto.TIMESTAMP_LEITURA;
                entity.VALOR_LEITURA = dto.VALOR_LEITURA;
                entity.UNIDADE_MEDIDA = dto.UNIDADE_MEDIDA;

                await _repository.UpdateAsync(entity);
                return dto;
            }
            catch
            {
                return null;
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                return await _repository.DeleteAsync(id);
            }
            catch
            {
                return false;
            }
        }
    }
}
