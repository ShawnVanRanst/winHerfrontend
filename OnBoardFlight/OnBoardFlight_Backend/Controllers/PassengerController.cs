using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnBoardFlight_Backend.Model;
using OnBoardFlight_Backend.Data.IRepository;
using OnBoardFlight_Backend.Data.DTO;

namespace OnBoardFlight_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PassengerController : ControllerBase
    {
        private readonly IPassengerRepository _passengerRepository;

        public PassengerController(IPassengerRepository passengerRepository)
        {
            _passengerRepository = passengerRepository;
        }


        [HttpGet]
        public IEnumerable<Passenger> GetPassengers()
        {
            return _passengerRepository.GetPassengers().OrderBy(p => p.Seat);
        }

        [HttpGet("{seat}")]
        public IActionResult GetPassengerBySeat(string seat)
        {
            Passenger passenger = _passengerRepository.GetPassengerBySeat(seat);
            if(passenger == null)
            {
                return NotFound();
            }
            return Ok(new PassengerDTO(passenger));
        }

        [HttpPut]
        public IActionResult UpdatePassenger(ChangeSeatsPassengersDTO passengerDTO)
        {
            if(passengerDTO == null)
            {
                return BadRequest();
            }
            Passenger passenger1 = _passengerRepository.GetPassengerById(passengerDTO.UserId1);
            Passenger passenger2 = _passengerRepository.GetPassengerById(passengerDTO.UserId2);
            _passengerRepository.ChangeSeats(passenger1, passenger2);
            _passengerRepository.SaveChanges();
            return NoContent();
        }


        
    }
}