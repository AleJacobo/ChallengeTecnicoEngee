namespace ChallengeTecnicoEngee.Domain.DTOs
{
    public class GetLogsVisitaResponseDto
    {
        public long NumeroVisita { get; set; }
        public string DiaVisita { get; set; }
        public string HoraVisita { get; set; }

        public long? EmpleadoVisitadoId { get; set; }
        public string EmpleadoVisitado { get; set; }

        public string SectorVisitado { get; set; }
    }
}
