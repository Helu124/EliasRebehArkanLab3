namespace BerrasBioLab.Models
{
    public class Showcase
    {
        public int Id { get; set; }
        public virtual Movie? Movie { get; set; }
        public int MovieId { get; set; }
        public virtual Salon? Salon { get; set; }
        public int SalonId { get; set; }
        public int? AvailableSeats { get; set; }
        public DateTime? StartTime { get; set; }

        
    }
}
