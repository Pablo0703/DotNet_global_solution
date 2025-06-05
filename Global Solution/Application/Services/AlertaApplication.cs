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
    public class AlertaApplication : IAlertaApplication
    {
        private readonly IAlertaRepository _repository;

        public AlertaApplication(IAlertaRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<AlertaDto>> GetAllAsync()
        {
            try
            {
                var alertas = await _repository.GetAllAsync();
                return alertas.Select(a => new AlertaDto
                {
                    ID_ALERTA = a.ID_ALERTA,
                    ID_AREA = a.ID_AREA,
                    ID_LEITURA_GATILHO = a.ID_LEITURA_GATILHO,
                    TIMESTAMP_ALERTA = a.TIMESTAMP_ALERTA,
                    TIPO_ALERTA = a.TIPO_ALERTA,
                    MENSAGEM_ALERTA = a.MENSAGEM_ALERTA,
                    STATUS_ALERTA = a.STATUS_ALERTA
                });
            }
            catch
            {
                return null;
            }
        }

        public async Task<AlertaDto> GetByIdAsync(int id)
        {
            try
            {
                var a = await _repository.GetByIdAsync(id);
                if (a == null) return null;

                return new AlertaDto
                {
                    ID_ALERTA = a.ID_ALERTA,
                    ID_AREA = a.ID_AREA,
                    ID_LEITURA_GATILHO = a.ID_LEITURA_GATILHO,
                    TIMESTAMP_ALERTA = a.TIMESTAMP_ALERTA,
                    TIPO_ALERTA = a.TIPO_ALERTA,
                    MENSAGEM_ALERTA = a.MENSAGEM_ALERTA,
                    STATUS_ALERTA = a.STATUS_ALERTA
                };
            }
            catch
            {
                return null;
            }
        }

        public async Task<AlertaDto> AddAsync(AlertaDto dto)
        {
            try
            {
                var entity = new AlertaEntity
                {
                    ID_AREA = dto.ID_AREA,
                    ID_LEITURA_GATILHO = dto.ID_LEITURA_GATILHO,
                    TIMESTAMP_ALERTA = dto.TIMESTAMP_ALERTA,
                    TIPO_ALERTA = dto.TIPO_ALERTA?.ToUpper(),
                    MENSAGEM_ALERTA = dto.MENSAGEM_ALERTA,
                    STATUS_ALERTA = dto.STATUS_ALERTA?.ToUpper()
                };

                var created = await _repository.AddAsync(entity);
                dto.ID_ALERTA = created.ID_ALERTA;
                return dto;
            }
            catch
            {
                return null;
            }
        }

        public async Task<AlertaDto> UpdateAsync(int id, AlertaDto dto)
        {
            try
            {
                var entity = await _repository.GetByIdAsync(id);
                if (entity == null) return null;

                entity.ID_AREA = dto.ID_AREA;
                entity.ID_LEITURA_GATILHO = dto.ID_LEITURA_GATILHO;
                entity.TIMESTAMP_ALERTA = dto.TIMESTAMP_ALERTA;
                entity.TIPO_ALERTA = dto.TIPO_ALERTA?.ToUpper();
                entity.MENSAGEM_ALERTA = dto.MENSAGEM_ALERTA;
                entity.STATUS_ALERTA = dto.STATUS_ALERTA?.ToUpper();

                var updated = await _repository.UpdateAsync(entity);

                return new AlertaDto
                {
                    ID_ALERTA = updated.ID_ALERTA,
                    ID_AREA = updated.ID_AREA,
                    ID_LEITURA_GATILHO = updated.ID_LEITURA_GATILHO,
                    TIMESTAMP_ALERTA = updated.TIMESTAMP_ALERTA,
                    TIPO_ALERTA = updated.TIPO_ALERTA,
                    MENSAGEM_ALERTA = updated.MENSAGEM_ALERTA,
                    STATUS_ALERTA = updated.STATUS_ALERTA
                };
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
