using OnBoardFlight.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnBoardFlight.ViewModel
{
    public static class DummyDataSource
    {
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
    }
}
