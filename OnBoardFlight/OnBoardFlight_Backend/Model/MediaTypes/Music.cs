using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnBoardFlight_Backend.Model.Media
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

        public Music(MusicCategory category, string resource)
        {
            Category = category;
            Resource = resource;
        }


        #endregion
    }
}
