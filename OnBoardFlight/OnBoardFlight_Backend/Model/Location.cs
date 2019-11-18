using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OnBoardFlight.Model
{
    public class Location
    {
        [Required]
        public int LocationId { get; set; }

        [Required]
        public string Airport { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string Country { get; set; }

        [Required]
        public DateTime Time { get; set; }
    }
}
