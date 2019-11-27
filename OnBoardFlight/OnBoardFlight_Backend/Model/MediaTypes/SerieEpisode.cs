using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnBoardFlight_Backend.Model.MediaTypes
{
    public class SerieEpisode: Media
    {

        #region Properties

        public int Episode { get; set; }

        public int Season { get; set; }

        //Path to get the serie episode
        public string Resource { get; set; }

        #endregion

        #region Constructors

        public SerieEpisode()
        {

        }

        public SerieEpisode(int episode, int season, string resource)
        {
            Episode = episode;
            Season = season;
            Resource = resource;
        }


        #endregion


    }
}
