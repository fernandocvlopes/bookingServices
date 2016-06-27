using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace bookingServices.ViewModels
{
    public class Booking
    {
        [Required]
        [StringLength(255, MinimumLength = 5)]
        public string Name { get; set; }

        [Required]
        public int Age { get; set; }

        [Required]
        public string Gender { get; set; }

        [Required]
        public int Weight { get; set; }

        public List<int> HealthProblems { get; set; }

        [Required]
        public string EventKey { get; set; }

        [Required]
        public DateTime ChosenDate { get; set; }

    }
}
