using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnBoardFlight.Model
{
    public class Flight
    {
  
        private Location _origin;

        public Location Origin
        {
            get { return _origin; }
            set { _origin = value; }
        }

        private Location location;

        public Location Destination
        {
            get { return location; }
            set { location = value; }
        }

    }
}
