using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnBoardFlight.Model.Helper
{
    public class CategoryAndListMusicHelper
    {
        private MusicCategory _category;

        public MusicCategory Category
        {
            get { return _category; }
            set { _category = value; }
        }

        private List<Music> _musicList;

        public List<Music> MusicList
        {
            get { return _musicList; }
            set { _musicList = value; }
        }

    }
}
