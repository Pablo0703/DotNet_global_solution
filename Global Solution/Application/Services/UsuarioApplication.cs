using Global_Solution.Application.Dtos;
using Global_Solution.Application.Interface;
using Global_Solution.Domain.Entities;
using Global_Solution.Domain.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Global_Solution.Application.Services
{
    public class UsuarioApplication : IUsuarioApplication
    {
        private readonly IUsuarioRepository _repository;

        public UsuarioApplication(IUsuarioRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<UsuarioDto>> GetAllAsync()
        {
            try
            {
                var usuarios = await _repository.GetAllAsync();
                return usuarios.Select(u => new UsuarioDto
                {
                    ID_USUARIO = u.ID_USUARIO,
                    NOME_USUARIO = u.NOME_USUARIO,
                    EMAIL = u.EMAIL,
                    TELEFONE = u.TELEFONE,
                    TIPO_USUARIO = u.TIPO_USUARIO,
                    SENHA_HASH = u.SENHA_HASH,
                    DATA_CADASTRO = u.DATA_CADASTRO
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao listar usuários: {ex.Message}");
                return Enumerable.Empty<UsuarioDto>(); // ✅ Corrigido
            }
        }

        public async Task<UsuarioDto> GetByIdAsync(int id)
        {
            try
            {
                var u = await _repository.GetByIdAsync(id);
                if (u == null) return null;

                return new UsuarioDto
                {
                    ID_USUARIO = u.ID_USUARIO,
                    NOME_USUARIO = u.NOME_USUARIO,
                    EMAIL = u.EMAIL,
                    TELEFONE = u.TELEFONE,
                    TIPO_USUARIO = u.TIPO_USUARIO,
                    SENHA_HASH = u.SENHA_HASH,
                    DATA_CADASTRO = u.DATA_CADASTRO
                };
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao buscar usuário por ID: {ex.Message}");
                return null;
            }
        }

        public async Task<UsuarioDto> AddAsync(UsuarioDto dto)
        {
            try
            {
                var entity = new UsuarioEntity
                {
                    NOME_USUARIO = dto.NOME_USUARIO,
                    EMAIL = dto.EMAIL,
                    TELEFONE = dto.TELEFONE,
                    TIPO_USUARIO = dto.TIPO_USUARIO,
                    SENHA_HASH = dto.SENHA_HASH,
                    DATA_CADASTRO = DateTime.UtcNow
                };

                var created = await _repository.AddAsync(entity);
                dto.ID_USUARIO = created.ID_USUARIO;
                return dto;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao adicionar usuário: {ex.Message}");
                return null;
            }
        }

        public async Task<UsuarioDto> UpdateAsync(int id, UsuarioDto dto)
        {
            try
            {
                var entity = await _repository.GetByIdAsync(id);
                if (entity == null) return null;

                entity.NOME_USUARIO = dto.NOME_USUARIO;
                entity.EMAIL = dto.EMAIL;
                entity.TELEFONE = dto.TELEFONE;
                entity.TIPO_USUARIO = dto.TIPO_USUARIO;
                entity.SENHA_HASH = dto.SENHA_HASH;

                await _repository.UpdateAsync(id, entity);
                return dto;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao atualizar usuário: {ex.Message}");
                return null; 
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                return await _repository.DeleteAsync(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao deletar usuário: {ex.Message}");
                return false;
            }
        }
    }
}
