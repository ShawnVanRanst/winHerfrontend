using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace OnBoardFlight.Model.WeatherApi
{
    [DataContract]
    class List
    {
        [DataMember]
        public int dt { get; set; }
        [DataMember]
        public Main main { get; set; }
        [DataMember]
        public List<Weather> weather { get; set; }
        [DataMember]
        public Wind wind { get; set; }
        [DataMember]
        public string dt_txt { get; set; }
    }
}
