using ChallengeTecnicoEngee.Domain.DTOs;
using ChallengeTecnicoEngee.Domain.Entities;
using ChallengeTecnicoEngee.Services.Interfaces;
using Domain.Entities;
using Domain.Exceptions;
using Infraestructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ChallengeTecnicoEngee.Services
{
    public class LogsVisitasService : ILogsVisitaService
    {
        private readonly ApplicationDbContext _context;
        public LogsVisitasService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Create(RenaperRequestDto request)
        {
            if (!request.Visita.SectorId.HasValue || !request.Visita.EmpleadoVisitadoId.HasValue)
                throw new APIException("No se especifico el area/empleado motivo de la visita");

            var empleadoVisitado = await _context.Empleados.FirstOrDefaultAsync(x => x.Id == request.Visita.EmpleadoVisitadoId)
                ?? throw new APIException("No se encontro el empleado especificado a visitar ");

            var visita = new LogVisita
            {
                NombresVisitante = request.Nombres.Trim(),
                ApellidosVisitante = request.Apellido.Trim(),
                NumeroDocumentoVisitante = request.DNI.Trim(),
                NumeroTarjetaIngreso = request.Visita.NumeroTarjetaIngreso.Trim(),
                FechaHoraIngreso = DateTime.Now,
                EmpleadoVisitadoId = request.Visita.EmpleadoVisitadoId.HasValue && request.Visita.SectorId == 0 ?
                    request.Visita.EmpleadoVisitadoId.Value : null,
                SectorId = request.Visita.EmpleadoVisitadoId.HasValue && request.Visita.SectorId == 0
                    ? empleadoVisitado.SectorId : request.Visita.SectorId.Value
            };

            _context.LogsVisitas.Add(visita);

            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<GetLogsVisitaResponseDto>> GetAll()
        {
            var visita = 0;

            return await _context.LogsVisitas.Include(x => x.EmpleadoVisitado).Include(x => x.Sector)
                .Select(x => new GetLogsVisitaResponseDto
                {
                    NumeroVisita = visita + 1,
                    DiaVisita = x.FechaHoraIngreso.Date.ToString("dd/MM/yyyy"),
                    HoraVisita = x.FechaHoraIngreso.ToString("HH:mm"),
                    EmpleadoVisitadoId = x.EmpleadoVisitadoId.HasValue ? x.EmpleadoVisitadoId : null,
                    EmpleadoVisitado = x.EmpleadoVisitadoId.HasValue ? $"{x.EmpleadoVisitado.Nombres} {x.EmpleadoVisitado.Apellidos}" : null,
                    SectorVisitado = x.Sector.Descripcion
                }).ToListAsync();
        }

        public async Task Delete(long id)
        {
            var visita = await _context.LogsVisitas.FirstOrDefaultAsync(x => x.Id == id)
                ?? throw new APIException("No se encontro la visita seleccionada para eliminar");

            visita.Activo = false;
            _context.Update(visita);
            await _context.SaveChangesAsync();
        }
    }
}
