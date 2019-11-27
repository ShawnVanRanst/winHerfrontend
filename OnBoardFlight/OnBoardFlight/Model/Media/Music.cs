using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnBoardFlight.Model
{
    public class Music: Media.Media
    {
        private MusicCategory musicCategory;

        public MusicCategory Category
        {
            get { return musicCategory; }
            set { musicCategory = value; }
        }

        // path to get the song
        private string _resource;

        public string Resource
        {
            get { return _resource; }
            set { _resource = value; }
        }

    }
}
