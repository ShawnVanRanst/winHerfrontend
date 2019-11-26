using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnBoardFlight.Model
{
    public class SerieEpisode: Media.Media
    {
        private int _episode;

        public int Episode
        {
            get { return _episode; }
            set { _episode = value; }
        }

        private int _season;

        public int Season
        {
            get { return _season; }
            set { _season = value; }
        }

        // path to get the serie episode
        private string _resource;

        public string Resource
        {
            get { return _resource; }
            set { _resource = value; }
        }

    }
}
