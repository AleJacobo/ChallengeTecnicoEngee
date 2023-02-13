using System.ComponentModel.DataAnnotations;

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
