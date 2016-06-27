using System.Collections.Generic;

namespace bookingServices.Models
{
    public class UnavailableDatesResult
    {
        public bool Success { get; set; }
        public List<long> UnavailableDates { get; set; }
        public string Message { get; set; }
    }
}
