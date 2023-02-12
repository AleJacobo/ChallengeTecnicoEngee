namespace Domain.Interfaces.Entities
{
    public interface IAuditable
    {
        public DateTime FechaAlta { get; set; }
        public DateTime? FechaModficiacion { get; set; }
        public DateTime? FechaEliminacion { get; set; }
    }
}
