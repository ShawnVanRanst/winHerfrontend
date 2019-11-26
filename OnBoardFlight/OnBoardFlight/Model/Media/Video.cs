using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnBoardFlight.Model.Media
{
    public class Video : Media
    {
        private VideoCategory _category;

        public VideoCategory Category
        {
            get { return _category; }
            set { _category = value; }
        }
    }
}
