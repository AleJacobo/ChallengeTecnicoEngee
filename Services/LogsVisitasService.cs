using ChallengeTecnicoEngee.Services.Interfaces;
using Infraestructure.Data;

namespace ChallengeTecnicoEngee.Services
{
    public class LogsVisitasService : ILogsVisitaService
    {
        private readonly ApplicationDbContext _context;
        public LogsVisitasService(ApplicationDbContext context)
        {
            _context = context;
        }


    }
}
