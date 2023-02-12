using ChallengeTecnicoEngee.Domain.DTOs;
using ChallengeTecnicoEngee.Services.Interfaces;
using Domain.Exceptions;
using Infraestructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ChallengeTecnicoEngee.Services
{
    public class EmpleadosService : IEmpleadosService
    {
        private readonly ApplicationDbContext _context;
        public EmpleadosService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<GetAllEmpleadosSectorResponseDto>> GetAllPorSector(long id)
        {
            var sector = await _context.Sectores.FirstOrDefaultAsync(x => x.Id == id)
                ?? throw new APIException("No se encontro el sector solicitado");

            return await _context.Empleados.Include(x => x.Sector)
                .Where(x => x.SectorId == id)
                .Select(x => new GetAllEmpleadosSectorResponseDto
                {
                    EmpleadoId = x.Id,
                    NombreCompleto = $"{x.Nombres} {x.Apellidos}",
                    SectorDescripcion = sector.Descripcion,
                    SectorCodigo = sector.Codigo
                }).ToListAsync();
        }
    }
}
