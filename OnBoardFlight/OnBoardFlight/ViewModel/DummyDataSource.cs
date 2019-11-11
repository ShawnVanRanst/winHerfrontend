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
    }
}
