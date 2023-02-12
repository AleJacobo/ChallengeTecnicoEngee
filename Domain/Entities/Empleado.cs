using Domain.Entities.EntityBases;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChallengeTecnicoEngee.Domain.Entities
{
    [Table("Empleados")]
    public class Empleado : EntityBase
    {
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public long SectorId { get; set; }
        public Sector Sector { get; set; }
    }
}
