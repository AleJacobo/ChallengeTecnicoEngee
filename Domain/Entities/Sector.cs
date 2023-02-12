using ChallengeTecnicoEngee.Domain.Entities.EntityBases;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChallengeTecnicoEngee.Domain.Entities
{
    [Table("Sectores")]
    public class Sector : TypeBase
    {
        public ICollection<Empleado> Empleados { get; set; }
    }
}
