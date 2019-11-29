using OnBoardFlight_Backend.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OnBoardFlight_Backend.Data.DTO
{
    public class ChangeSeatsPassengersDTO
    {
        [Required]
        public int UserId1 { get; set; }

       
        [Required]
        public int UserId2 { get; set; }

        public ChangeSeatsPassengersDTO()
        {

        }

        public ChangeSeatsPassengersDTO(Passenger passenger1, Passenger passenger2)
        {
            UserId1 = passenger1.UserId;
            UserId2 = passenger2.UserId;
        }
    }
}
