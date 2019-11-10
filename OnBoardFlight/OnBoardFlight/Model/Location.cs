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

        private int _zipCode;

        public int ZipCode
        {
            get { return _zipCode; }
            set { _zipCode = value; }
        }

        private string _countryCode;

        public string CountryCode
        {
            get { return _countryCode; }
            set { _countryCode = value; }
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
