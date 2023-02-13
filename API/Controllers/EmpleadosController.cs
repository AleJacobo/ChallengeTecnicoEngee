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
        #region Constructor
        private readonly IEmpleadosService _empleadosService;
        public EmpleadosController(IEmpleadosService empleadosService)
        {
            _empleadosService = empleadosService;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Creacion de un empleado
        /// </summary>
        /// <param name="request">Formulario para la creacion de un empleado</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateEmpleadoRequestDto request)
        {
            var response = new Result();

            if (!ModelState.IsValid)
            {
                await response.Fail("Hay datos que no son correctos en el formulario, verifique la informacion");
                return BadRequest(response);
            }

            await _empleadosService.Create(request);

            return Ok();
        }

        /// <summary>
        /// Obtencion de un empleado, dado su Id
        /// </summary>
        /// <param name="id">del empleado a consultar</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<GetEmpleadoByIdResponseDto>> GetById([FromRoute] long id)
        {
            var response = new Result();

            var empleado = await _empleadosService.GetById(id);

            if (empleado == null)
            {
                await response.Fail("No se ha podido encontrar el Empleado solicitado");
                return BadRequest(response);
            }

            return Ok(empleado);
        }

        /// <summary>
        /// Obtencion de todos los empleados en la base de datos
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetAllEmpleadosResponseDto>>> GetAll()
        {
            var response = new Result();

            var empleados = await _empleadosService.GetAll();

            if (!empleados.Any())
            {
                await response.Fail("Se ha ejecutado la operacion, pero no se hayaron resultados");
                return BadRequest(response);
            }

            return Ok(empleados);
        }

        /// <summary>
        /// Obtencion de los empleados asociados a un sector
        /// </summary>
        /// <param name="id">del sector donde se consultan los empleados</param>
        /// <returns></returns>
        [HttpGet("sector/{id}")]
        public async Task<ActionResult<IEnumerable<GetAllEmpleadosResponseDto>>> GetAllPorSector([FromRoute] long id)
        {
            var response = new Result();

            var empleados = await _empleadosService.GetAllPorSector(id);

            if (!empleados.Any())
            {
                await response.Fail("Se ha ejecutado la operacion, pero no se hayaron resultados");
                return BadRequest(response);
            }

            return Ok(empleados);
        }

        /// <summary>
        /// Modificacion de un empleado, dado su id y un formulario de modificacion
        /// </summary>
        /// <param name="id">del empleado a modificar</param>
        /// <param name="request">formulario para actualizar al empleado</param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] long id, [FromBody] UpdateEmpleadoRequestDto request)
        {
            var response = new Result();

            if (!ModelState.IsValid)
            {
                await response.Fail("Hay informacion requerida que no ingreso, verifique el formulario");
                return BadRequest(response);
            }

            await _empleadosService.Update(id, request);

            return Ok();
        }

        /// <summary>
        /// Eliminacion por baja logica del empleado 
        /// </summary>
        /// <param name="id">del empleado a eliminar</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] long id)
        {
            await _empleadosService.Delete(id);
            return Ok();
        }
        #endregion
    }
}
