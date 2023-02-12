using ChallengeTecnicoEngee.Domain.DTOs;

namespace ChallengeTecnicoEngee.Services.Interfaces
{
    public interface IEmpleadosService
    {
        Task<IEnumerable<GetAllEmpleadosSectorResponseDto>> GetAllPorSector(long id);

    }
}
