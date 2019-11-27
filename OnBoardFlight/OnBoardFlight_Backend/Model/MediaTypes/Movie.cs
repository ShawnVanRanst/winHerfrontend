using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnBoardFlight_Backend.Model.MediaTypes
{
    public class Movie: Video
    {

        public string Resource { get; set; }

        public Movie(string resource): base()
        {
            Resource = resource;
        }
    }
}
