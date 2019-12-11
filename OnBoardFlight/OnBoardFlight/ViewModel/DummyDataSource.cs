using OnBoardFlight.Model;
using OnBoardFlight.Model.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnBoardFlight.ViewModel
{
    public static class DummyDataSource
    {
        public static List<Music> MusicList()
        {
            List<Music> ml = new List<Music>();
            foreach (Media m in MediaList)
            {
                if (m.GetType() == typeof(Music))
                {
                    ml.Add((Music)m);
                }
            }
            return ml;
        }

        public static List<Video> MovieList()
        {
            List<Video> ml = new List<Video>();
            foreach (Media m in MediaList)
            {
                if (m.GetType() == typeof(Movie))
                {
                    ml.Add((Video)m);
                }
            }
            return ml;
        }

        public static List<Video> SerieList()
        {
            List<Video> sl = new List<Video>();
            foreach (Media m in MediaList)
            {
                if (m.GetType() == typeof(Serie))
                {
                    sl.Add((Video)m);
                }
            }
            return sl;
        }

        public static List<Media> MediaList { get; set; } = new List<Media>()
        {
            new Music(){Id = 0,Category = MusicCategory.edm,Description = "edm artist",DisplayImage = "music.png",Resource = "PiewPiew.mp3",Title = "edm song title"},
            new Music(){Id = 2,Category = MusicCategory.house,Description = "house artist",DisplayImage = "music.png",Resource = "PiewPiew.mp3",Title = "house song title"},
            new Music(){Id = 3,Category = MusicCategory.pop,Description = "pop artist",DisplayImage = "music.png",Resource = "PiewPiew.mp3",Title = "pop song title"},
            new Music(){Id = 4,Category = MusicCategory.rap,Description = "24KGoldn",DisplayImage = "music.png",Resource = "ALotToLose.mp3",Title = "A Lot To Lose"},
            new Movie(){Id = 0, Category = VideoCategory.action, Description = "movie action", DisplayImage = "movie.jfif", Resource = "AtjeVoorDeSfeer.mp4", Title = "Atje voor de sfeer"},
            new Movie(){Id = 2, Category = VideoCategory.comedy, Description = "movie comedy", DisplayImage = "movie.jfif", Resource = "AtjeVoorDeSfeer.mp4", Title = "Atje voor de sfeer"},
            new Movie(){Id = 1, Category = VideoCategory.horror, Description = "movie horror", DisplayImage = "movie.jfif", Resource = "AtjeVoorDeSfeer.mp4", Title = "Atje voor de sfeer"},
            new Serie(){Id = 0, Category = VideoCategory.action, Description = "serie 1", DisplayImage = "movie.jfif", Title = "title", Episodes = new List<SerieEpisode>(){
                new SerieEpisode(){Id = 0, Description = "s1e1", DisplayImage = "movie.jfif", Episode = 1, Season = 1, Resource = "AtjeVoorDeSfeer.mp4", Title = "AVDS s1e1"},
                new SerieEpisode(){Id = 1, Description = "s1e2", DisplayImage = "movie.jfif", Episode = 2, Season = 1, Resource = "AtjeVoorDeSfeer.mp4", Title = "AVDS s1e2"},
                new SerieEpisode(){Id = 2, Description = "s1e3", DisplayImage = "movie.jfif", Episode = 3, Season = 1, Resource = "AtjeVoorDeSfeer.mp4", Title = "AVDS s1e3"},
            }
            },
            new Serie(){Id = 1, Category = VideoCategory.comedy, Description = "serie 2", DisplayImage = "movie.jfif", Title = "title2", Episodes = new List<SerieEpisode>(){
                new SerieEpisode(){Id = 0, Description = "s1e1", DisplayImage = "movie.jfif", Episode = 1, Season = 1, Resource = "AtjeVoorDeSfeer.mp4", Title = "AVDS s1e1"},
                new SerieEpisode(){Id = 1, Description = "s1e2", DisplayImage = "movie.jfif", Episode = 2, Season = 1, Resource = "AtjeVoorDeSfeer.mp4", Title = "AVDS s1e2"},
                new SerieEpisode(){Id = 2, Description = "s1e3", DisplayImage = "movie.jfif", Episode = 3, Season = 1, Resource = "AtjeVoorDeSfeer.mp4", Title = "AVDS s1e3"},
            }
            },
            new Serie(){Id = 2, Category = VideoCategory.horror, Description = "serie 3", DisplayImage = "movie.jfif", Title = "title231", Episodes = new List<SerieEpisode>(){
                new SerieEpisode(){Id = 0, Description = "s1e1", DisplayImage = "movie.jfif", Episode = 1, Season = 1, Resource = "AtjeVoorDeSfeer.mp4", Title = "AVDS s1e1"},
                new SerieEpisode(){Id = 1, Description = "s1e2", DisplayImage = "movie.jfif", Episode = 2, Season = 1, Resource = "AtjeVoorDeSfeer.mp4", Title = "AVDS s1e2"},
                new SerieEpisode(){Id = 2, Description = "s1e3", DisplayImage = "movie.jfif", Episode = 3, Season = 1, Resource = "AtjeVoorDeSfeer.mp4", Title = "AVDS s1e3"},
            }
            }
        };

        public static Flight Flight { get; set; } = new Flight()
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

        public static Model.Passenger Passenger2 { get; set; } = new Model.Passenger()
        {
            Login = "2",
            FirstName = "Arno",
            LastName = "Boel",
            TravelCompany = new List<Model.Passenger>(),
            ChatList = new List<Chat>()
        };

        public static Model.Passenger Passenger3 { get; set; } = new Model.Passenger()
        {
            Login = "3",
            FirstName = "Shawn",
            LastName = "van Ranst",
            TravelCompany = new List<Model.Passenger>(),
            ChatList = new List<Chat>()
        };

        public static Model.Passenger Passenger4 { get; set; } = new Model.Passenger()
        {
            Login = "4",
            FirstName = "pas4",
            LastName = "last4",
            TravelCompany = new List<Model.Passenger>(),
            ChatList = new List<Chat>()
        };

        private static List<Model.Passenger> TravelCompany { get; set; } = new List<Model.Passenger>()
        {
            Passenger2,
            Passenger3
        };



        public static Model.Passenger Passenger { get; set; } = new Model.Passenger()
        {
            Login = "1",
            FirstName = "Ruben",
            LastName = "Grillaert",
            TravelCompany = new List<Model.Passenger>(),
            ChatList = new List<Chat>()
        };


        public static User CabinMember { get; set; } = new Model.CabinCrew()
        {
            Login = "McJoel",
            Password = "Rijbewijs"
        };

        public static Model.Passenger getPassenger()
        {
            Model.Passenger passenger = Passenger;
            passenger.AddTravelCompanionWithChat(Passenger2);
            passenger.AddTravelCompanionWithChat(Passenger3);
            return passenger;
        }

        public static Model.Product Product1 { get; set; } = new Product()
        {
            Description = "Coca cola 33cl",
            ImageLink = "link",
            Price = 3.0,
            Category = Model.ProductCategory.Drinks
        };

        public static Model.Product Product2 { get; set; } = new Product()
        {
            Description = "Fanta 33cl",
            ImageLink = "link",
            Price = 3.0,
            Category = Model.ProductCategory.Drinks
        };

        public static Model.Product Product3 { get; set; } = new Product()
        {
            Description = "Paprika chips 50g",
            ImageLink = "link",
            Price = 2.5,
            Category = Model.ProductCategory.Food
        };

        public static Model.Product Product4 { get; set; } = new Product()
        {
            Description = "Rolex horloge",
            ImageLink = "link",
            Price = 10000.0,
            Category = Model.ProductCategory.Drinks
        };

        public static Model.Orderline Orderline1 { get; set; } = new Model.Orderline(Product1)
        {
            Number = 3
        };

        public static Model.Orderline Orderline2 { get; set; } = new Model.Orderline(Product3)
        {
            Number = 1
        };

        public static Model.Orderline Orderline3 { get; set; } = new Model.Orderline(Product2)
        {
            Number = 2
        };

        public static Model.Orderline Orderline4 { get; set; } = new Model.Orderline(Product4)
        {
            Number = 1
        };


        public static Model.Order Order1 { get; set; } = new Model.Order(Passenger)
        {
            Time = DateTime.Now,
            Orderlines = new List<Model.Orderline>() { Orderline1, Orderline2}
        };

        public static Model.Order Order2 { get; set; } = new Model.Order(Passenger)
        {
            Time = DateTime.Now.AddMinutes(-15),
            Orderlines = new List<Model.Orderline>() { Orderline3}
        };

        public static Model.Order Order3 { get; set; } = new Model.Order(Passenger)
        {
            Time = DateTime.Now.AddMinutes(-10),
            Orderlines = new List<Model.Orderline>() { Orderline4 }
        };
    }
}
