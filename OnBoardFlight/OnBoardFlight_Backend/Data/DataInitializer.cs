using Microsoft.AspNetCore.Identity;
using OnBoardFlight.Model;
using OnBoardFlight_Backend.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnBoardFlight.Data
{
    public class DataInitializer
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly UserManager<IdentityUser> _userManager;

        public DataInitializer(ApplicationDbContext applicationDbContext)
        {
            _dbContext = applicationDbContext;
            //_userManager = userManager;
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

                #region Users
                User crewMember = new CabinCrew { Login = "crewmember1" };
                //await CreateUser(crewMember.Login, "P@ssword1");
                _dbContext.Users.Add(crewMember);
                #endregion

                #region Save changes
                _dbContext.SaveChanges();
                #endregion

            }


        }


        //private async Task CreateUser(string username, string password)
        //{
        //    var user = new IdentityUser { UserName = username};
        //    await _userManager.CreateAsync(user, password);
        //}
    }

}
