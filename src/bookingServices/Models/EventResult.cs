namespace bookingServices.Models
{
    public class EventResult
    {
        public bool Success { get; set; }
        public Event SelectedEvent { get; set; }
        public string Message { get; set; }
    }
}
