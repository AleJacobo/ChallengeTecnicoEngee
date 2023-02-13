using ChallengeTecnicoEngee.Domain.DTOs;
using ChallengeTecnicoEngee.Domain.Entities;
using ChallengeTecnicoEngee.Services.Interfaces;
using Domain.Exceptions;
using Infraestructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace ChallengeTecnicoEngee.Services
{
    public class EmpleadosService : IEmpleadosService
    {
        private readonly ApplicationDbContext _context;
        public EmpleadosService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Create(CreateEmpleadoRequestDto request)
        {
            var sector = await _context.Sectores.FirstOrDefaultAsync(x => x.Id == request.SectorId)
                ?? throw new APIException("El sector especificado no existe en el sistema");

            _context.Add(new Empleado
            {
                Nombres = request.Nombres.Trim(),
                Apellidos = request.Apellidos.Trim(),
                SectorId = request.SectorId
            });

            await _context.SaveChangesAsync();
        }

        public async Task<GetEmpleadoByIdResponseDto> GetById(long id)
        {
            var empleado = await _context.Empleados.Include(x => x.Sector)
                .FirstOrDefaultAsync(x => x.Id == id)
                ?? throw new APIException("No se encontro al empleado solicitado");

            return new GetEmpleadoByIdResponseDto
            {
                EmpleadoId = empleado.Id,
                NombreCompleto = $"{empleado.Nombres} {empleado.Apellidos}",
                SectorDescripcion = empleado.Sector.Descripcion,
                SectorCodigo = empleado.Sector.Codigo
            };
        }

        public async Task<IEnumerable<GetAllEmpleadosResponseDto>> GetAll()
        {
            return await _context.Empleados.Include(x => x.Sector)
                .Select(x => new GetAllEmpleadosResponseDto
                {
                    EmpleadoId = x.Id,
                    NombreCompleto = $"{x.Nombres} {x.Apellidos}",
                    SectorDescripcion = x.Sector.Descripcion,
                    SectorCodigo = x.Sector.Codigo
                }).ToListAsync();
        }

        public async Task<IEnumerable<GetAllEmpleadosResponseDto>> GetAllPorSector(long id)
        {
            var sector = await _context.Sectores.FirstOrDefaultAsync(x => x.Id == id)
                ?? throw new APIException("No se encontro el sector solicitado");

            return await _context.Empleados.Include(x => x.Sector)
                .Where(x => x.SectorId == id)
                .Select(x => new GetAllEmpleadosResponseDto
                {
                    EmpleadoId = x.Id,
                    NombreCompleto = $"{x.Nombres} {x.Apellidos}",
                    SectorDescripcion = sector.Descripcion,
                    SectorCodigo = sector.Codigo
                }).ToListAsync();
        }

        public async Task Update(long id, UpdateEmpleadoRequestDto request)
        {
            var empleado = await _context.Empleados.FirstOrDefaultAsync(x => x.Id == id)
                ?? throw new APIException("No se encontro el empleado a modificar");

            empleado.Nombres = !request.Nombres.IsNullOrEmpty() ? request.Nombres.Trim()
                : throw new APIException("El/los nombre/s del empleado no pueden estar vacios o ser espacios en blanco");
            empleado.Apellidos = !request.Apellidos.IsNullOrEmpty() ? request.Apellidos.Trim()
                : throw new APIException("El/los apellido/s del empleado no pueden estar vacion o ser espacios en blanco");
            empleado.SectorId = !_context.Sectores.Any(x => x.Id == request.SectorId) ? request.SectorId
                : throw new APIException("No se encontro registrado el nuevo sector ingresado, favor de verificar la informacion");

            _context.Update(empleado);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(long id)
        {
            var empleado = await _context.Empleados.FirstOrDefaultAsync(x => x.Id == id)
                ?? throw new APIException("No se encontro el empleado a eliminar");

            empleado.Activo = false;

            _context.Update(empleado);
            await _context.SaveChangesAsync();
        }
    }
}
