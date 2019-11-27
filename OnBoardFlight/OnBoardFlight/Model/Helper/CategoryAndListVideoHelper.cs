using OnBoardFlight.Model.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnBoardFlight.Model.Helper
{
    public class CategoryAndListVideoHelper
    {
        private VideoCategory _category;

        public VideoCategory Category
        {
            get { return _category; }
            set { _category = value; }
        }

        private List<Video> _videoList;

        public List<Video> VideoList
        {
            get { return _videoList; }
            set { _videoList = value; }
        }

    }
}
