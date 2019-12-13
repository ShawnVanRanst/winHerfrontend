using Microsoft.AspNetCore.Identity;
using OnBoardFlight.Model;
using OnBoardFlight_Backend.Model;
using OnBoardFlight_Backend.Model.MediaTypes;
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

                #region Media

                    #region Movie
                    Movie movie1 = new Movie("movie.jfif", "movie1", "This is movie1", VideoCategory.action, "AtjeVoorDeSfeer.mp4");
                    _dbContext.Mediafiles.Add(movie1);

                    Movie movie2 = new Movie("movie.jfif", "movie2", "This is movie2", VideoCategory.comedy, "AtjeVoorDeSfeer.mp4");
                    _dbContext.Mediafiles.Add(movie2);

                    Movie movie3 = new Movie("movie.jfif", "movie3", "This is movie3", VideoCategory.horror, "AtjeVoorDeSfeer.mp4");
                    _dbContext.Mediafiles.Add(movie3);
                    #endregion

                    #region Serie
                    Serie serie1 = new Serie("movie.jfif", "serie1", "This is serie1", VideoCategory.action);
                    _dbContext.Mediafiles.Add(serie1);

                    Serie serie2 = new Serie("movie.jfif", "serie2", "This is serie2", VideoCategory.action);
                    _dbContext.Mediafiles.Add(serie2);

                    Serie serie3 = new Serie("movie.jfif", "serie3", "This is serie3", VideoCategory.action);
                    _dbContext.Mediafiles.Add(serie3);
                #endregion

                    #region Serie Episode
                    SerieEpisode episode1 = new SerieEpisode("movie.jfif", "episode1", "This is episode 1", 1, 1, "AtjeVoorDeSfeer.mp4");
                    serie1.AddEpisode((SerieEpisode)episode1);
                    _dbContext.Mediafiles.Add(episode1);

                    SerieEpisode episode2 = new SerieEpisode("movie.jfif", "episode2", "This is episode 2", 2, 1, "AtjeVoorDeSfeer.mp4");
                    serie1.AddEpisode((SerieEpisode)episode2);
                    _dbContext.Mediafiles.Add(episode2);

                    SerieEpisode episode3 = new SerieEpisode("movie.jfif", "episode1", "This is episode 1", 1, 1, "AtjeVoorDeSfeer.mp4");
                    serie2.AddEpisode((SerieEpisode)episode3);
                    _dbContext.Mediafiles.Add(episode3);

                    SerieEpisode episode4 = new SerieEpisode("movie.jfif", "episode2", "This is episode 2", 2, 1, "AtjeVoorDeSfeer.mp4");
                    serie2.AddEpisode((SerieEpisode)episode4);
                    _dbContext.Mediafiles.Add(episode4);

                    SerieEpisode episode5 = new SerieEpisode("movie.jfif", "episode1", "This is episode 1", 1, 1, "AtjeVoorDeSfeer.mp4");
                    serie3.AddEpisode((SerieEpisode)episode5);
                    _dbContext.Mediafiles.Add(episode5);

                    SerieEpisode episode6 = new SerieEpisode("movie.jfif", "episode2", "This is episode 2", 2, 1, "AtjeVoorDeSfeer.mp4");
                    serie1.AddEpisode((SerieEpisode)episode6);
                    _dbContext.Mediafiles.Add(episode6);

                    #endregion

                    #region Music
                    Music song1 = new Music("music.png", "Song1", "This is song1", MusicCategory.house, "PiewPiew.mp3");
                    _dbContext.Mediafiles.Add(song1);

                    Music song2 = new Music("music.png", "Song2", "This is song2", MusicCategory.edm, "PiewPiew.mp3");
                    _dbContext.Mediafiles.Add(song2);

                    Music song3 = new Music("music.png", "Song3", "This is song3", MusicCategory.pop, "PiewPiew.mp3");
                    _dbContext.Mediafiles.Add(song3);
                #endregion
                #endregion
                #region Product
                Product product1 = new Product("cola 33cl","link", 3.00,ProductCategory.Drinks);
                _dbContext.Products.Add(product1);
                Product product2 = new Product("fanta 33cl", "link", 3.00, ProductCategory.Drinks);
                _dbContext.Products.Add(product2);
                Product product3 = new Product("ice tea 33cl", "link", 3.00, ProductCategory.Drinks);
                _dbContext.Products.Add(product3);

                Product product4 = new Product("hamburger", "link", 5.00, ProductCategory.Food);
                _dbContext.Products.Add(product4);

                Product product5 = new Product("horloge", "link", 50.00, ProductCategory.Gifts);
                _dbContext.Products.Add(product5);


                #endregion
                #region Order
                Passenger passenger1MetOrder = passenger1 as Passenger;
                _dbContext.Passengers.Add(passenger1MetOrder);
                Order order1 = new Order(passenger1MetOrder, DateTime.MinValue);
                _dbContext.Orders.Add(order1);
                #endregion
                #region Orderline
                Orderline orderline1 = new Orderline(2, product1, order1);
                _dbContext.Orderlines.Add(orderline1);
                order1.AddOrderline(orderline1);
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
