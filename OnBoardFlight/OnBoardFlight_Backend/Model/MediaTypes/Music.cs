using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnBoardFlight_Backend.Model.MediaTypes
{
    public class Music: Media
    {

        #region Properties

        public MusicCategory Category{ get; set; }

        public string Resource { get; set; }
        #endregion

        #region Consructors
        public Music()
        {

        }

        public Music(string displayImage, string title, string description, MusicCategory category, string resource): base(displayImage, title, description)
        {
            Category = category;
            Resource = resource;
        }


        #endregion

    }
}
