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
    public class InscricaoAlertaApplication : IInscricaoAlertaApplication
    {
        private readonly IInscricaoAlertaRepository _repository;

        public InscricaoAlertaApplication(IInscricaoAlertaRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<InscricaoAlertaDto>> GetAllAsync()
        {
            try
            {
                var inscricoes = await _repository.GetAllAsync();
                return inscricoes.Select(i => new InscricaoAlertaDto
                {
                    ID_INSCRICAO = i.ID_INSCRICAO,
                    ID_USUARIO = i.ID_USUARIO,
                    ID_AREA = i.ID_AREA,
                    TIMESTAMP_INSCRICAO = i.TIMESTAMP_INSCRICAO,
                    RECEBER_EMAIL = i.RECEBER_EMAIL == 1 ? true : false,
                    RECEBER_SMS = i.RECEBER_SMS == 1 ? true : false,
                    RECEBER_PUSH = i.RECEBER_PUSH == 1 ? true : false
                });
            }
            catch
            {
                return null;
            }
        }

        public async Task<InscricaoAlertaDto> GetByIdAsync(int id)
        {
            try
            {
                var i = await _repository.GetByIdAsync(id);
                if (i == null) return null;

                return new InscricaoAlertaDto
                {
                    ID_INSCRICAO = i.ID_INSCRICAO,
                    ID_USUARIO = i.ID_USUARIO,
                    ID_AREA = i.ID_AREA,
                    TIMESTAMP_INSCRICAO = i.TIMESTAMP_INSCRICAO,
                    RECEBER_EMAIL = i.RECEBER_EMAIL == 1 ? true: false,
                    RECEBER_SMS = i.RECEBER_SMS == 1 ? true : false,
                    RECEBER_PUSH = i.RECEBER_PUSH == 1 ? true : false
                };
            }
            catch
            {
                return null;
            }
        }

        public async Task<InscricaoAlertaDto> AddAsync(InscricaoAlertaDto dto)
        {
            try
            {
                var entity = new InscricaoAlertaEntity
                {
                    ID_USUARIO = dto.ID_USUARIO,
                    ID_AREA = dto.ID_AREA,
                    TIMESTAMP_INSCRICAO = dto.TIMESTAMP_INSCRICAO,
                    RECEBER_EMAIL = dto.RECEBER_EMAIL == true ? 1 : 0,
                    RECEBER_SMS = dto.RECEBER_SMS == true ? 1 : 0,
                    RECEBER_PUSH = dto.RECEBER_PUSH == true ? 1 : 0

                };

                var created = await _repository.AddAsync(entity);
                dto.ID_INSCRICAO = created.ID_INSCRICAO;
                return dto;
            }
            catch
            {
                return null;
            }
        }

        public async Task<InscricaoAlertaDto> UpdateAsync(int id, InscricaoAlertaDto dto)
        {
            try
            {
                var entity = await _repository.GetByIdAsync(dto.ID_INSCRICAO);
                if (entity == null) return null;

                entity.ID_USUARIO = dto.ID_USUARIO;
                entity.ID_AREA = dto.ID_AREA;
                entity.TIMESTAMP_INSCRICAO = dto.TIMESTAMP_INSCRICAO;
                entity.RECEBER_EMAIL = dto.RECEBER_EMAIL == true ? 1:0;
                entity.RECEBER_SMS = dto.RECEBER_SMS == true ? 1 : 0;
                entity.RECEBER_PUSH = dto.RECEBER_PUSH == true ? 1 : 0;

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
