namespace ChallengeTecnicoEngee.Domain.DTOs
{
    public class CreateLogVisitaRequestDto
    {
        public string NumeroTarjetaIngreso { get; set; }
        public long? SectorId { get; set; }
        public long? EmpleadoVisitadoId { get; set; }
    }
}
