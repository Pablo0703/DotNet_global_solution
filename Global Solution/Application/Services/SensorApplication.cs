using Global_Solution.Application.Dtos;
using Global_Solution.Application.Interface;
using Global_Solution.Domain.Entities;
using Global_Solution.Domain.Interface;

public class SensorApplication : ISensorApplication
{
    private readonly ISensorRepository _repository;

    public SensorApplication(ISensorRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<SensorDto>> GetAllAsync()
    {
        try
        {
            var sensores = await _repository.GetAllAsync();
            return sensores.Select(s => new SensorDto
            {
                ID_SENSOR = s.ID_SENSOR,
                ID_AREA = s.ID_AREA,
                TIPO_SENSOR = s.TIPO_SENSOR,
                MODELO = s.MODELO,
                DATA_INSTALACAO = s.DATA_INSTALACAO,
                ULTIMA_MANUTENCAO = s.ULTIMA_MANUTENCAO,
                STATUS_SENSOR = s.STATUS_SENSOR
            });
        }
        catch
        {
            return null;
        }
    }

    public async Task<SensorDto> GetByIdAsync(string id)
    {
        try
        {
            var s = await _repository.GetByIdAsync(id);
            if (s == null) return null;

            return new SensorDto
            {
                ID_SENSOR = s.ID_SENSOR,
                ID_AREA = s.ID_AREA,
                TIPO_SENSOR = s.TIPO_SENSOR,
                MODELO = s.MODELO,
                DATA_INSTALACAO = s.DATA_INSTALACAO,
                ULTIMA_MANUTENCAO = s.ULTIMA_MANUTENCAO,
                STATUS_SENSOR = s.STATUS_SENSOR
            };
        }
        catch
        {
            return null;
        }
    }

    public async Task<SensorDto> AddAsync(SensorDto dto)
    {
        try
        {
            var entity = new SensorEntity
            {
                ID_SENSOR = dto.ID_SENSOR,
                ID_AREA = dto.ID_AREA,
                TIPO_SENSOR = dto.TIPO_SENSOR,
                MODELO = dto.MODELO,
                DATA_INSTALACAO = dto.DATA_INSTALACAO,
                ULTIMA_MANUTENCAO = dto.ULTIMA_MANUTENCAO,
                STATUS_SENSOR = dto.STATUS_SENSOR
            };

            var created = await _repository.AddAsync(entity);
            dto.ID_SENSOR = created.ID_SENSOR;
            return dto;
        }
        catch
        {
            return null;
        }
    }

    public async Task<SensorDto> UpdateAsync(string id, SensorDto dto)
    {
        try
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null) return null;

            entity.ID_AREA = dto.ID_AREA;
            entity.TIPO_SENSOR = dto.TIPO_SENSOR;
            entity.MODELO = dto.MODELO;
            entity.DATA_INSTALACAO = dto.DATA_INSTALACAO;
            entity.ULTIMA_MANUTENCAO = dto.ULTIMA_MANUTENCAO;
            entity.STATUS_SENSOR = dto.STATUS_SENSOR;

            await _repository.UpdateAsync(entity);
            return dto;
        }
        catch
        {
            return null;
        }
    }

    public async Task<bool> DeleteAsync(string id)
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
