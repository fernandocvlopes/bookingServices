using bookingServices.ViewModels;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;

namespace bookingServices.Models
{
    public class BookingRepository : IBookingRepository
    {
        // Functions for date compatibility with javascript
        private long DatetimeMinTimeTicks = (new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).Ticks;
        private long ToJavaScriptMilliseconds(DateTime dt)
        {
            return (long)((dt.ToUniversalTime().Ticks - DatetimeMinTimeTicks) / 10000);
        }

        private ILogger<BookingRepository> _logger;

        public BookingRepository(ILogger<BookingRepository> logger)
        {
            _logger = logger;
        }

        public IEnumerable<HealthProblem> GetAllHealthProblems()
        {
            // Here it is supossed to access a DB to find the health problems list
            var HealthProblems = new List<HealthProblem>()
                    {
                        new HealthProblem() { ID = 1, Description = "Endometriosis"},
                        new HealthProblem() { ID = 2, Description = "Epilepsy"},
                        new HealthProblem() { ID = 3, Description = "Fibromyalgia"},
                        new HealthProblem() { ID = 4, Description = "Hypertension" },
                        new HealthProblem() { ID = 5, Description = "Mental illness" }
                    };

            return HealthProblems;
        }

        public UnavailableDatesResult GetAllUnavailableDates(string eventName)
        {
            var result = new UnavailableDatesResult()
            {
                Success = false
            };

            // Here it is supposed to check the existence of the requested event consuming a service
            if (eventName.ToUpper() != "SKY_DIVING")
            {
                result.Message = "Failed to find the event.";
                _logger.LogError($"Failed to find the event: {eventName}");
            }
            else
            {
                // Here it is supposed to access a DB to find the unavailable dates for the requested event
                // The dates are converted to long for compatibility with JS
                result.UnavailableDates = new List<long>()
                    {
                        ToJavaScriptMilliseconds(new DateTime(2016, 8, 1)),
                        ToJavaScriptMilliseconds(new DateTime(2016, 8, 9)),
                        ToJavaScriptMilliseconds(new DateTime(2016, 8, 13)),
                        ToJavaScriptMilliseconds(new DateTime(2016, 8, 19)),
                        ToJavaScriptMilliseconds(new DateTime(2016, 8, 25)),
                        ToJavaScriptMilliseconds(new DateTime(2016, 8, 31))
                    };

                result.Message = "Success";
                result.Success = true;
            }

            return result;
        }

        public EventResult GetEvent(string eventName)
        {
            var result = new EventResult()
            {
                Success = false
            };

            // Here it is supposed to check the existence of the requested event consuming a service
            if (eventName.ToUpper() != "SKY_DIVING")
            {
                result.Message = "Failed to find the event.";
                _logger.LogError($"Failed to find the event: {eventName}");
            }
            else
            {
                // Here it is supposed to access a DB to find the event info
                string description =
                    @"Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, 
                        quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum 
                        dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.";

                result.SelectedEvent = new Event()
                    {
                        Key = "Sky_Diving",
                        Name = "Sky Diving",
                        Description = description,
                        Photo = "img/skydiving.jpg",
                        Location = "Belo Horizonte - Brazil",
                        Price = 149,
                        StartDate = ToJavaScriptMilliseconds(new DateTime(2016, 8, 1)),
                        EndDate = ToJavaScriptMilliseconds(new DateTime(2016, 8, 31))
                };

                result.Message = "Success";
                result.Success = true;
            }

            return result;
        }

        public Boolean AddBooking(Booking booking)
        {
            // Necessary to validate the booking (even the date again) through service. If any problem happen, return false

            // Access a DB to save the booking
            return true;
        }
    }
}
