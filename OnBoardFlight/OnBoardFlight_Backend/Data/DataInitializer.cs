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
                Flight flight = new Flight()
                {
                    Origin = new Location()
                    {
                        Airport = "Brussels Airport",
                        City = "Zaventem",
                        CountryIso = "bel",
                        Country = "Belgium",
                        Time = new DateTime(2019, 12, 15, 10, 45, 0)
                    },
                    Destination = new Location()
                    {
                        Airport = "Internationale Luchthaven Barcelona",
                        City = "Barcelona",
                        CountryIso = "esp",
                        Country = "Spain",
                        Time = new DateTime(2019, 12, 15, 12, 25, 0)
                    }
                };
                _dbContext.Flights.Add(flight);
                #endregion

                #region Notification
                Notification notification1 = new Notification { Title = "Safety First", Content = "This is a plain, not some kampin kitsch party", SinglePerson = true };
                _dbContext.Add(notification1);
                Notification notification2 = new Notification { Title = "Safety First", Content = "This is a plain, not some kampin kitsch party", SinglePerson = true };
                _dbContext.Add(notification2);
                Notification notification3 = new Notification { Title = "Safety First", Content = "This is a plain, not some kampin kitsch party", SinglePerson = true };
                _dbContext.Add(notification3);
                Notification notification4 = new Notification { Title = "Safety First", Content = "This is a plain, not some kampin kitsch party", SinglePerson = true };
                _dbContext.Add(notification4);
                #endregion

                #region Users
                CabinCrew crewMember1 = new CabinCrew { Login = "RR", Pass = "pornhub", FirstName = "Riley", LastName = "Reid", Flight = flight };
                //await CreateUser(crewMember.Login, "P@ssword1");
                _dbContext.Users.Add(crewMember1);

                CabinCrew crewMember2 = new CabinCrew { Login = "crewmember2", Pass = "234", Flight = flight };
                _dbContext.Users.Add(crewMember2);

                Passenger passenger1 = new Passenger("Arno", "Boel", "01A") { Flight = flight };
                passenger1.AddNotification(notification1);
                

                Passenger passenger2 = new Passenger("Ruben", "Grillaert", "20D") { Flight = flight };
                passenger2.AddNotification(notification2);
                

                Passenger passenger3 = new Passenger("Shawn", "Van Ranst", "12F") { Flight = flight };
                passenger3.AddNotification(notification3);
                

                Passenger passenger4 = new Passenger("Melissa", "Van Belle", "01B") { Flight = flight };
                passenger4.AddNotification(notification4);

                #region Chat
                passenger1.AddTravelCompanion(passenger2);
                passenger1.AddTravelCompanion(passenger3);
                passenger1.AddTravelCompanion(passenger4);
                passenger2.AddTravelCompanion(passenger3);
                passenger2.AddTravelCompanion(passenger4);
                passenger3.AddTravelCompanion(passenger4);
                passenger1.Chats.First().AddMessage(new Message(passenger2, "Test 123 test"));
                #endregion

                _dbContext.Users.Add(passenger1);
                _dbContext.Users.Add(passenger2);
                _dbContext.Users.Add(passenger3);
                _dbContext.Users.Add(passenger4);
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

                #region MindField
                Serie MindField = new Serie("MF.jpg", "Mind Field",
                    "In Mind Field, host Michael Stevens brings his passion for science to " +
                    "his most ambitious subject yet: something we still know very little about, " +
                    "human behavior." +
                    "Using real subjects (including guest stars and Michael himself) " +
                    "Mind Field reveals some of the most mind-blowing, " +
                    "significant, and least-understood aspects of the human psyche." +
                    "Through expert interviews, rare footage from historical experiments, " +
                    "and brand-new, ground-breaking demonstrations of human nature at work, " +
                    "Mind Field explores the surprising things we know (and don’t know) about " +
                    "why people are the way they are.", VideoCategory.science);

                _dbContext.Add(MindField);

                List<SerieEpisode> serieEpisodes = new List<SerieEpisode>();

                serieEpisodes.Add(new SerieEpisode("MF1.png", "Isolation", "What happens when your brain is deprived of stimulation? What effect does being cut off from interaction with the outside world have on a person?  What effect does it have on me, when I am locked in a windowless, soundproof isolation chamber for three days?", 1, 1, "AtjeVoorDeSfeer.mp4"));
                serieEpisodes.Add(new SerieEpisode("MF2.png", "Conformity", "We are all unique individuals.  We follow the beat of our own drum.  We wouldn’t throw our own beliefs out the window just to fit in...or would we?  In this episode of Mind Field, I demonstrate the strong, human urge to conform, and just how far people will go to fall in with the crowd.", 2, 1, "AtjeVoorDeSfeer.mp4"));
                serieEpisodes.Add(new SerieEpisode("MF3.png", "Destruction", "We humans love to build, create, and organize.  So why do we also love to destroy things?  Can violently breaking stuff really help to calm us down, or does it just make us more angry?  In this episode of Mind Field, I take a hard look at our urge to destroy.", 3, 1, "AtjeVoorDeSfeer.mp4"));
                serieEpisodes.Add(new SerieEpisode("MF4.png", "Artificial Intelligence", "So you say you love your computer or smartphone...but can it love you back? As we become more dependent on technology, and our technology becomes more lifelike, where does the line between human and computer lie?  And what happens when our relationships become romantic?", 4, 1, "AtjeVoorDeSfeer.mp4"));
                serieEpisodes.Add(new SerieEpisode("MF5.png", "Freedom of Choice", "We may value having Freedom of Choice, but are we actually happier when we have limited choices...or even no choice at all?  Do we truly have control over our decisions, or are they really predetermined by other forces?  My fellow YouTubers and I have our minds read by a “box” that reveals who - or what - is really calling the shots. ", 5, 1, "AtjeVoorDeSfeer.mp4"));
                serieEpisodes.Add(new SerieEpisode("MF6.png", "Touch", "How much of the sensations we feel is determined by our physical bodies?  Maybe our minds play a bigger role than we know.  I’ll see if people can be tricked into feeling intense physical pain, even though it’s all in their heads.  I’ll also look at a machine that makes it possible for you to tickle yourself, and I’ll show you a weird physical illusion you can do at home.", 6, 1, "AtjeVoorDeSfeer.mp4"));
                serieEpisodes.Add(new SerieEpisode("MF7.png", "In Your Face", "How much do we communicate through facial expressions?  Are our expressions affected by our moods, or is it the other way around?  And what happens to your ability to relate to others when your facial muscles are frozen by Botox?  In this episode of Mind Field, I take a look at what’s In Your Face.", 7, 1, "AtjeVoorDeSfeer.mp4"));
                serieEpisodes.Add(new SerieEpisode("MF8.png", "Dou You Know Yourself?", "What makes you, you?  If even the most basic parts of you, like your memories or your past, can be forgotten or manipulated, how can you know ever really know who “you” are?  In this episode of Mind Field I look at how well Do You Know Yourself?", 8, 1, "AtjeVoorDeSfeer.mp4"));

                foreach(SerieEpisode serie in serieEpisodes)
                {
                    MindField.AddEpisode(serie);
                    _dbContext.Mediafiles.Add(serie);
                }

                
                #endregion

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
                Product product1 = new Product("cola 33cl","link", 3.00,ProductCategory.Drinks, false);
                _dbContext.Products.Add(product1);
                Product product2 = new Product("fanta 33cl", "link", 3.00, ProductCategory.Drinks, false);
                _dbContext.Products.Add(product2);
                Product product3 = new Product("ice tea 33cl", "link", 3.00, ProductCategory.Drinks, false);
                _dbContext.Products.Add(product3);

                Product product4 = new Product("hamburger", "link", 5.00, ProductCategory.Food, false);
                _dbContext.Products.Add(product4);

                Product product5 = new Product("horloge", "link", 50.00, ProductCategory.Gifts, false);
                _dbContext.Products.Add(product5);


                #endregion


                #region Order

                

                Passenger passenger1MetOrder = passenger1 as Passenger;
                _dbContext.Passengers.Add(passenger1MetOrder);
                Passenger passenger2MetOrder = passenger2 as Passenger;
                _dbContext.Passengers.Add(passenger2MetOrder);
                Order order1 = new Order(passenger1MetOrder, DateTime.MinValue);
                Order order2 = new Order(passenger1MetOrder, DateTime.MinValue);
                Order order3 = new Order(passenger2MetOrder, DateTime.MinValue);

                #region Orderline
                Orderline orderline1 = new Orderline(2, product1, order1);
                Orderline orderline2 = new Orderline(1, product2, order2);
                Orderline orderline3 = new Orderline(3, product3, order3);
                #endregion

                order1.AddOrderline(orderline1);
                order2.AddOrderline(orderline2);
                order3.AddOrderline(orderline3);
                _dbContext.Orders.Add(order1);
                _dbContext.Orders.Add(order2);
                _dbContext.Orders.Add(order3);
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
