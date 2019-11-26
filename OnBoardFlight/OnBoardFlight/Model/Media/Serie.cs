using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnBoardFlight.Model
{
    public class Serie : Media.Video
    {
        private List<SerieEpisode> _episodes;

        public List<SerieEpisode> Episodes
        {
            get { return _episodes; }
            set { _episodes = value; }
        }
    }
}
