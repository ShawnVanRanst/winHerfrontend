using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnBoardFlight_Backend.Model
{
    public class Weather
    {

        #region Properties
        public int WeatherId { get; set; }

        public double Temp { get; set; }

        public string Description { get; set; }

        public double WindSpeed { get; set; }

        public double WindOrientation { get; set; }

        public string When { get; set; }

        #endregion

        #region Constructors

        public Weather()
        {

        }

        public Weather(double temp, string description, double windSpeed, double windOrientation, string when)
        {
            Temp = temp;
            Description = description;
            WindSpeed = windSpeed;
            WindOrientation = windOrientation;
            When = when;
        }


        #endregion
    }
}
