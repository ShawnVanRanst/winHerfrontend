using Microsoft.EntityFrameworkCore;
using OnBoardFlight.Model;
using OnBoardFlight_Backend.Model.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnBoardFlight.Data.Repository
{
    public class FlightRepository : IFlightRepository
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly DbSet<Flight> _flights;

        public FlightRepository(ApplicationDbContext applicationDbContext)
        {
            _dbContext = applicationDbContext;
            _flights = applicationDbContext.Flights;
        }

        public IEnumerable<Flight> GetFlights()
        {
            throw new NotImplementedException();
        }
    }
}
