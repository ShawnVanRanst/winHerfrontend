using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnBoardFlight.Model.Media
{
    public class Movie: Video
    {
        private string _resource;

        public string Resource
        {
            get { return _resource; }
            set { _resource = value; RaisePropertyChanged("Resource"); }
        }
    }
}
