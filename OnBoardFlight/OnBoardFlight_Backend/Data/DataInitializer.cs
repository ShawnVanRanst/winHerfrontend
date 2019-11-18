using OnBoardFlight.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnBoardFlight.Data
{
    public class DataInitializer
    {
        private readonly ApplicationDbContext _dbContext;

        public DataInitializer(ApplicationDbContext applicationDbContext)
        {
            _dbContext = applicationDbContext;
        }

        public async Task InitializeData()
        {
            _dbContext.Database.EnsureDeleted();
            if(_dbContext.Database.EnsureCreated())
            {

                #region Flights
                Flight f = new Flight() {Destination = "test", Origin = "testa" };
                _dbContext.Flights.Add(f);
                #endregion

                #region Save changes
                _dbContext.SaveChanges();
                #endregion

            }


        }
    }
}
