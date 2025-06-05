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
    public class AreaRiscoApplication : IAreaRiscoApplication
    {
        private readonly IAreaRiscoRepository _repository;

        public AreaRiscoApplication(IAreaRiscoRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<AreaRiscoDto>> GetAllAsync()
        {
            try
            {
                var areas = await _repository.GetAllAsync();
                return areas.Select(a => new AreaRiscoDto
                {
                    ID_AREA = a.ID_AREA,
                    NOME_AREA = a.NOME_AREA,
                    LATITUDE = a.LATITUDE,
                    LONGITUDE = a.LONGITUDE,
                    NIVEL_NORMAL_ESTACAO_SECA = a.NIVEL_NORMAL_ESTACAO_SECA,
                    NIVEL_NORMAL_ESTACAO_CHUVA = a.NIVEL_NORMAL_ESTACAO_CHUVA,
                    NIVEL_ALERTA_PREVENTIVO = a.NIVEL_ALERTA_PREVENTIVO,
                    NIVEL_ALERTA_EMERGENCIA = a.NIVEL_ALERTA_EMERGENCIA,
                    NIVEL_EVACUACAO = a.NIVEL_EVACUACAO,
                    AREA_ALAGADA_ALERTA = a.AREA_ALAGADA_ALERTA,
                    AREA_ALAGADA_EMERGENCIA = a.AREA_ALAGADA_EMERGENCIA,
                    METODO_MEDICAO_NIVEL = a.METODO_MEDICAO_NIVEL,
                    METODO_MEDICAO_EXTENSAO = a.METODO_MEDICAO_EXTENSAO,
                    FONTE_DADOS = a.FONTE_DADOS,
                    ULTIMA_ATUALIZACAO = a.ULTIMA_ATUALIZACAO,
                    RESPONSAVEL_ATUALIZACAO = a.RESPONSAVEL_ATUALIZACAO,
                    DESCRICAO = a.DESCRICAO
                });
            }
            catch
            {
                return null;
            }
        }

        public async Task<AreaRiscoDto> GetByIdAsync(int id)
        {
            try
            {
                var a = await _repository.GetByIdAsync(id);
                if (a == null) return null;

                return new AreaRiscoDto
                {
                    ID_AREA = a.ID_AREA,
                    NOME_AREA = a.NOME_AREA,
                    LATITUDE = a.LATITUDE,
                    LONGITUDE = a.LONGITUDE,
                    NIVEL_NORMAL_ESTACAO_SECA = a.NIVEL_NORMAL_ESTACAO_SECA,
                    NIVEL_NORMAL_ESTACAO_CHUVA = a.NIVEL_NORMAL_ESTACAO_CHUVA,
                    NIVEL_ALERTA_PREVENTIVO = a.NIVEL_ALERTA_PREVENTIVO,
                    NIVEL_ALERTA_EMERGENCIA = a.NIVEL_ALERTA_EMERGENCIA,
                    NIVEL_EVACUACAO = a.NIVEL_EVACUACAO,
                    AREA_ALAGADA_ALERTA = a.AREA_ALAGADA_ALERTA,
                    AREA_ALAGADA_EMERGENCIA = a.AREA_ALAGADA_EMERGENCIA,
                    METODO_MEDICAO_NIVEL = a.METODO_MEDICAO_NIVEL,
                    METODO_MEDICAO_EXTENSAO = a.METODO_MEDICAO_EXTENSAO,
                    FONTE_DADOS = a.FONTE_DADOS,
                    ULTIMA_ATUALIZACAO = a.ULTIMA_ATUALIZACAO,
                    RESPONSAVEL_ATUALIZACAO = a.RESPONSAVEL_ATUALIZACAO,
                    DESCRICAO = a.DESCRICAO
                };
            }
            catch
            {
                return null;
            }
        }

        public async Task<AreaRiscoDto> AddAsync(AreaRiscoDto dto)
        {
            try
            {
                var entity = new AreaRiscoEntity
                {
                    NOME_AREA = dto.NOME_AREA,
                    LATITUDE = dto.LATITUDE,
                    LONGITUDE = dto.LONGITUDE,
                    NIVEL_NORMAL_ESTACAO_SECA = dto.NIVEL_NORMAL_ESTACAO_SECA,
                    NIVEL_NORMAL_ESTACAO_CHUVA = dto.NIVEL_NORMAL_ESTACAO_CHUVA,
                    NIVEL_ALERTA_PREVENTIVO = dto.NIVEL_ALERTA_PREVENTIVO,
                    NIVEL_ALERTA_EMERGENCIA = dto.NIVEL_ALERTA_EMERGENCIA,
                    NIVEL_EVACUACAO = dto.NIVEL_EVACUACAO,
                    AREA_ALAGADA_ALERTA = dto.AREA_ALAGADA_ALERTA,
                    AREA_ALAGADA_EMERGENCIA = dto.AREA_ALAGADA_EMERGENCIA,
                    METODO_MEDICAO_NIVEL = dto.METODO_MEDICAO_NIVEL,
                    METODO_MEDICAO_EXTENSAO = dto.METODO_MEDICAO_EXTENSAO,
                    FONTE_DADOS = dto.FONTE_DADOS,
                    ULTIMA_ATUALIZACAO = dto.ULTIMA_ATUALIZACAO,
                    RESPONSAVEL_ATUALIZACAO = dto.RESPONSAVEL_ATUALIZACAO,
                    DESCRICAO = dto.DESCRICAO
                };

                var created = await _repository.AddAsync(entity);
                dto.ID_AREA = created.ID_AREA;
                return dto;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao salvar Área de Risco: " + ex.Message, ex);
            }
        }


        public async Task<AreaRiscoDto> UpdateAsync(int id, AreaRiscoDto dto)
        {
            try
            {
                var entity = await _repository.GetByIdAsync(dto.ID_AREA);
                if (entity == null) return null;

                entity.NOME_AREA = dto.NOME_AREA;
                entity.LATITUDE = dto.LATITUDE;
                entity.LONGITUDE = dto.LONGITUDE;
                entity.NIVEL_NORMAL_ESTACAO_SECA = dto.NIVEL_NORMAL_ESTACAO_SECA;
                entity.NIVEL_NORMAL_ESTACAO_CHUVA = dto.NIVEL_NORMAL_ESTACAO_CHUVA;
                entity.NIVEL_ALERTA_PREVENTIVO = dto.NIVEL_ALERTA_PREVENTIVO;
                entity.NIVEL_ALERTA_EMERGENCIA = dto.NIVEL_ALERTA_EMERGENCIA;
                entity.NIVEL_EVACUACAO = dto.NIVEL_EVACUACAO;
                entity.AREA_ALAGADA_ALERTA = dto.AREA_ALAGADA_ALERTA;
                entity.AREA_ALAGADA_EMERGENCIA = dto.AREA_ALAGADA_EMERGENCIA;
                entity.METODO_MEDICAO_NIVEL = dto.METODO_MEDICAO_NIVEL;
                entity.METODO_MEDICAO_EXTENSAO = dto.METODO_MEDICAO_EXTENSAO;
                entity.FONTE_DADOS = dto.FONTE_DADOS;
                entity.ULTIMA_ATUALIZACAO = dto.ULTIMA_ATUALIZACAO;
                entity.RESPONSAVEL_ATUALIZACAO = dto.RESPONSAVEL_ATUALIZACAO;
                entity.DESCRICAO = dto.DESCRICAO;

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
