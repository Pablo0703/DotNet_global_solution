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
    public class NotificacaoApplication : INotificacaoApplication
    {
        private readonly INotificacaoRepository _repository;

        public NotificacaoApplication(INotificacaoRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<NotificacaoDto>> GetAllAsync()
        {
            try
            {
                var notificacoes = await _repository.GetAllAsync();
                return notificacoes.Select(n => new NotificacaoDto
                {
                    ID_NOTIFICACAO = n.ID_NOTIFICACAO,
                    ID_ALERTA = n.ID_ALERTA,
                    ID_USUARIO = n.ID_USUARIO,
                    TIMESTAMP_ENVIO = n.TIMESTAMP_ENVIO,
                    CANAL_ENVIO = n.CANAL_ENVIO,
                    STATUS_ENVIO = n.STATUS_ENVIO
                });
            }
            catch
            {
                return null;
            }
        }

        public async Task<NotificacaoDto> GetByIdAsync(int id)
        {
            try
            {
                var n = await _repository.GetByIdAsync(id);
                if (n == null) return null;

                return new NotificacaoDto
                {
                    ID_NOTIFICACAO = n.ID_NOTIFICACAO,
                    ID_ALERTA = n.ID_ALERTA,
                    ID_USUARIO = n.ID_USUARIO,
                    TIMESTAMP_ENVIO = n.TIMESTAMP_ENVIO,
                    CANAL_ENVIO = n.CANAL_ENVIO,
                    STATUS_ENVIO = n.STATUS_ENVIO
                };
            }
            catch
            {
                return null;
            }
        }

        public async Task<NotificacaoDto> AddAsync(NotificacaoDto dto)
        {
            try
            {
                var entity = new NotificacaoEntity
                {
                    ID_ALERTA = dto.ID_ALERTA,
                    ID_USUARIO = dto.ID_USUARIO,
                    TIMESTAMP_ENVIO = dto.TIMESTAMP_ENVIO,
                    CANAL_ENVIO = dto.CANAL_ENVIO,
                    STATUS_ENVIO = dto.STATUS_ENVIO
                };

                var created = await _repository.AddAsync(entity);
                dto.ID_NOTIFICACAO = created.ID_NOTIFICACAO;
                return dto;
            }
            catch
            {
                return null;
            }
        }

        public async Task<NotificacaoDto> UpdateAsync(int id, NotificacaoDto dto)
        {
            try
            {
                var entity = await _repository.GetByIdAsync(dto.ID_NOTIFICACAO);
                if (entity == null) return null;

                entity.ID_ALERTA = dto.ID_ALERTA;
                entity.ID_USUARIO = dto.ID_USUARIO;
                entity.TIMESTAMP_ENVIO = dto.TIMESTAMP_ENVIO;
                entity.CANAL_ENVIO = dto.CANAL_ENVIO;
                entity.STATUS_ENVIO = dto.STATUS_ENVIO;

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
