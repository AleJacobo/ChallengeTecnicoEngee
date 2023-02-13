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

        /// <summary>
        /// Creacion de una visita al edificio
        /// </summary>
        /// <param name="request">objeto compuesto, que tiene tanto el request solicitado de renaper como la request para la creacion como tal</param>
        /// <returns></returns>
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

        /// <summary>
        /// Obtiene todos las visitas
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// Eliminacion de una visita
        /// </summary>
        /// <param name="id">de la visita a eliminar</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] long id)
        {
            await _logsVisitaService.Delete(id);

            return Ok();
        } 
        #endregion
    }
}
