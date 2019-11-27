using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnBoardFlight_Backend.Model.Media
{
    public class Serie: Video
    {

        #region Properties

        public ICollection<SerieEpisode> Episodes { get; set; }
        #endregion

        #region Constructors
        public Serie()
        {
            Episodes = new List<SerieEpisode>();
        }

        #endregion

        #region Methods

        public void AddEpisode(SerieEpisode episode)
        {
            Episodes.Add(episode);
        }
        #endregion
    }
}
