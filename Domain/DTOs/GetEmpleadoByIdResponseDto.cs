using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeTecnicoEngee.Domain.DTOs
{
    public class GetEmpleadoByIdResponseDto
    {
        public long EmpleadoId { get; set; }
        public string NombreCompleto { get; set; }
        public string SectorDescripcion { get; set; }
        public string SectorCodigo { get; set; }
    }
}
