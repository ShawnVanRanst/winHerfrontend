using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnBoardFlight.Model
{
    public class Location
    {

        private string _airport;

        public string Airport
        {
            get { return _airport; }
            set { _airport = value; }
        }

        private string _city;

        public string City
        {
            get { return _city; }
            set { _city = value; }
        }

        private string _countryIso;

        public string CountryIso
        {
            get { return _countryIso; }
            set { _countryIso = value; }
        }


        private string _country;

        public string Country
        {
            get { return _country; }
            set { _country = value; }
        }

        private DateTime _time;

        public DateTime Time
        {
            get { return _time; }
            set { _time = value; }
        }

    }
}
