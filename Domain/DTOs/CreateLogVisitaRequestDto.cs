using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeTecnicoEngee.Domain.DTOs
{
    public class CreateLogVisitaRequestDto
    {
        public string NumeroTarjetaIngreso { get; set; }
        public long? SectorId { get; set; }
        public long? EmpleadoVisitadoId { get; set; }
    }
}
