using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeTecnicoEngee.Domain.DTOs
{
    public class UpdateEmpleadoRequestDto
    {
        [Required]
        public string Nombres { get; set; }
        
        [Required]
        public string Apellidos { get; set; }
        
        [Required]
        public long SectorId { get; set; }
    }
}
