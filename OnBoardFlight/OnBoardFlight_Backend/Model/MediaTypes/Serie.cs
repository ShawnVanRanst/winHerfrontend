using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnBoardFlight_Backend.Model.MediaTypes
{
    public class Serie: Video
    {

        #region Properties

        public ICollection<SerieEpisode> Episodes { get; set; } = new List<SerieEpisode>();
        #endregion

        #region Constructors
        public Serie()
        {
        }

        public Serie(string displayImage, string title, string description, VideoCategory category) : base(displayImage, title, description, category)
        {

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
