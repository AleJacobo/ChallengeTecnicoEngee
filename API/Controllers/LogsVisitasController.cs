using ChallengeTecnicoEngee.Domain.DTOs;
using ChallengeTecnicoEngee.Services.Interfaces;
using Domain.Common;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace ChallengeTecnicoEngee.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogsVisitasController : Controller
    {
        #region Constructor
        private readonly ILogsVisitaService _logsVisitaService;
        public LogsVisitasController(ILogsVisitaService logsVisitaService)
        {
            _logsVisitaService = logsVisitaService;
        }
        #endregion

        #region Methods
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] RenaperRequestDto request)
        {
            var response = new Result();

            if (request == null || (request.Apellido.IsNullOrEmpty() && request.Nombres.IsNullOrEmpty()))
            {
                await response.Fail("Se debe especificar nombre/s y apellido/s del visitante");
                return BadRequest(response);
            }

            await _logsVisitaService.Create(request);

            return Ok();
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetLogsVisitaResponseDto>>> GetAll()
        {
            var response = new Result();

            var visitas = await _logsVisitaService.GetAll();

            if (!visitas.Any())
            {
                await response.Fail("Se ha ejecutado la operacion, pero no se hayaron resultados");
                return BadRequest(response);
            }

            return Ok(visitas);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] long id)
        {
            await _logsVisitaService.Delete(id);

            return Ok();
        } 
        #endregion
    }
}
