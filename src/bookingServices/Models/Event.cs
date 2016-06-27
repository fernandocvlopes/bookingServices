namespace bookingServices.Models
{
    public class Event
    {
        public string Key { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Photo { get; set; }
        public string Location { get; set; }
        public double Price { get; set; }
        public long StartDate { get; set; }
        public long EndDate { get; set; }

    }
}