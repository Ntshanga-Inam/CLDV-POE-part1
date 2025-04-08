using System.ComponentModel.DataAnnotations;

namespace EventBook.Models
{
    public class Event
    {
        public int EventId { get; set; }
        public string? EventName { get; set; }
        public DateTime EventDate { get; set; }
        public string? Description { get; set; }

        public ICollection<Booking> Bookings { get; set; }
        public object Venue { get; internal set; }
        public object VenueId { get; internal set; }
    }
}
