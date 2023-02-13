using ChallengeTecnicoEngee.Domain.DTOs;

namespace ChallengeTecnicoEngee.Services.Interfaces
{
    public interface ILogsVisitaService
    {
        Task Create(RenaperRequestDto request);
        Task<IEnumerable<GetLogsVisitaResponseDto>> GetAll();
        Task Delete(long id);
    }
}
