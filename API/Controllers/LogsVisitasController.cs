using ChallengeTecnicoEngee.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ChallengeTecnicoEngee.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogsVisitasController : Controller
    {
        private readonly ILogsVisitaService _logsVisitaService;

        public LogsVisitasController(ILogsVisitaService logsVisitaService)
        {
            _logsVisitaService = logsVisitaService;
        }


    }
}
