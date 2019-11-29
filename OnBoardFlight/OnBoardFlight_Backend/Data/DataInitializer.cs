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
                User crewMember1 = new CabinCrew { Login = "crewmember1" };
                //await CreateUser(crewMember.Login, "P@ssword1");
                _dbContext.Users.Add(crewMember1);

                User crewMember2 = new CabinCrew { Login = "crewmember2" };
                _dbContext.Users.Add(crewMember2);

                User passenger1 = new Passenger("Arno", "Boel", "01A");
                _dbContext.Users.Add(passenger1);

                User passenger2 = new Passenger("Ruben", "Grillaert", "20D");
                _dbContext.Users.Add(passenger2);

                User passenger3 = new Passenger("Shawn", "Van Ranst", "12F");
                _dbContext.Users.Add(passenger3);

                User passenger4 = new Passenger("Melissa", "Van Belle", "01B");
                _dbContext.Users.Add(passenger4);
                #endregion

                #region Chat
                Chat chat1 = new Chat("chat1");
                chat1.AddParticipants((Passenger)passenger3);
                chat1.AddParticipants((Passenger)passenger2);
                _dbContext.Chats.Add(chat1);

                Chat chat2 = new Chat("chat2");
                chat1.AddParticipants((Passenger)passenger1);
                chat1.AddParticipants((Passenger)passenger4);
                _dbContext.Chats.Add(chat2);

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
