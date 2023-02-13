namespace ChallengeTecnicoEngee.Domain.DTOs
{
    public class RenaperRequestDto
    {
        public string Apellido { get; set; }
        public string Nombres { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string DNI { get; set; }

        public CreateLogVisitaRequestDto Visita { get; set; }
    }
}
