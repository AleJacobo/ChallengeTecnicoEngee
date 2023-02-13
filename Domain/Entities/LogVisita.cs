using ChallengeTecnicoEngee.Domain.Entities;
using Domain.Entities.EntityBases;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    [Table("LogsVisitas")]
    public class LogVisita : EntityBase
    {
        public string NombresVisitante { get; set; }
        public string ApellidosVisitante { get; set; }
        public string NumeroDocumentoVisitante { get; set; }
        public DateTime FechaHoraIngreso { get; set; }
        public string NumeroTarjetaIngreso { get; set; }

        public long SectorId { get; set; }
        public Sector Sector { get; set; }

        public long? EmpleadoVisitadoId { get; set; }
        public Empleado? EmpleadoVisitado { get; set; }
    }
}
