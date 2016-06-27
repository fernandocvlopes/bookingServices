using bookingServices.ViewModels;
using System;
using System.Collections.Generic;

namespace bookingServices.Models
{
    public interface IBookingRepository
    {
        IEnumerable<HealthProblem> GetAllHealthProblems();
        UnavailableDatesResult GetAllUnavailableDates(string eventName);
        EventResult GetEvent(string eventName);
        Boolean AddBooking(Booking booking);
    }
}
