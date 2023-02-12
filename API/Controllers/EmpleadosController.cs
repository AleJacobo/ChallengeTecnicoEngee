using ChallengeTecnicoEngee.Domain.DTOs;
using ChallengeTecnicoEngee.Services.Interfaces;
using Domain.Common;
using Microsoft.AspNetCore.Mvc;

namespace ChallengeTecnicoEngee.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpleadosController : Controller
    {
        private readonly IEmpleadosService _empleadosService;
        public EmpleadosController(IEmpleadosService empleadosService)
        {
            _empleadosService = empleadosService;
        }

        [HttpGet("sector/{id}")]
        public async Task<ActionResult<IEnumerable<GetAllEmpleadosSectorResponseDto>>> GetAllPorSector([FromRoute] long id)
        {
            var response = new Result();

            var empleados = await _empleadosService.GetAllPorSector(id);
            
            if(!empleados.Any()) {
                await response.Fail("No se encontraron empleados en el sector especificado");
                return BadRequest(response);
            }

            return Ok(empleados);
        }
    }
}
