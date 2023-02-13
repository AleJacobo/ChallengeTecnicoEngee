using ChallengeTecnicoEngee.Domain.DTOs;

namespace ChallengeTecnicoEngee.Services.Interfaces
{
    public interface IEmpleadosService
    {
        Task Create(CreateEmpleadoRequestDto request);
        Task<GetEmpleadoByIdResponseDto> GetById(long id);
        Task<IEnumerable<GetAllEmpleadosResponseDto>> GetAll();
        Task<IEnumerable<GetAllEmpleadosResponseDto>> GetAllPorSector(long id);
        Task Update(long id, UpdateEmpleadoRequestDto request);
        Task Delete(long id);
    }
}
