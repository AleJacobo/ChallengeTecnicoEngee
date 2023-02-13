namespace ChallengeTecnicoEngee.Domain.DTOs
{
    public class GetAllEmpleadosResponseDto
    {
        public long EmpleadoId { get; set; }
        public string NombreCompleto { get; set; }
        public string SectorDescripcion { get; set; }
        public string SectorCodigo { get; set; }
    }
}
