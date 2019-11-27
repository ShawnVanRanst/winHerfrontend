using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnBoardFlight_Backend.Model;
using OnBoardFlight_Backend.Model.IRepository;

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
        public ActionResult<Passenger> GetPassengerBySeat(string seat)
        {
            Passenger passenger = _passengerRepository.GetPassengerBySeat(seat);
            if(passenger == null)
            {
                return NotFound();
            }
            return passenger;
        }

        [HttpPut("{id}")]
        public IActionResult UpdatePassenger(int id, Passenger passenger)
        {
            if( id != passenger.PassengerId)
            {
                return BadRequest();
            }
            _passengerRepository.UpdatePassenger(passenger);
            _passengerRepository.SaveChanges();
            return NoContent();
        }
    }
}