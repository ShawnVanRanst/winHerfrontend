using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace OnBoardFlight.Model.WeatherApi
{
    [DataContract]
    class City
    {
        [DataMember]
        public string name { get; set; }
        [DataMember]
        public string country { get; set; }
    }
}
