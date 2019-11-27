using Microsoft.EntityFrameworkCore;
using OnBoardFlight.Data;
using OnBoardFlight_Backend.Model;
using OnBoardFlight_Backend.Model.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnBoardFlight_Backend.Data.Repository
{
    public class PassengerRepository : IPassengerRepository
    {
        private readonly ApplicationDbContext _dbContext;

        private readonly DbSet<Passenger> _passengers;

        public PassengerRepository(ApplicationDbContext context)
        {
            _dbContext = context;
            _passengers = _dbContext.Passengers;
        }

        public Passenger GetPassengerBySeat(string seat)
        {
            return _passengers.Include(p => p.TravelCompany).Include(p => p.ChatList).Include(p => p.Orders).FirstOrDefault(p => p.Seat.Equals(seat));
        }

        public IEnumerable<Passenger> GetPassengers()
        {
            return _passengers.ToList();
        }

        public void UpdatePassenger(Passenger passenger)
        {
            _passengers.Update(passenger);
        }

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }

        
    }
}
