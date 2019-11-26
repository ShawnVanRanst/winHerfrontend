using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media.Imaging;

namespace OnBoardFlight.Model.Media
{
    public class Media
    {
        private int _id;

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        private string _displayImage;

        public string DisplayImage
        {
            get { return _displayImage; }
            set {
                _displayImage = value;
            }
        }

        private string _title;

        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }

        private string _description;

        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        public BitmapImage Image
        {
            get { return new BitmapImage(new Uri("http://openweathermap.org/img/w/03d.png", UriKind.Absolute)); }
        }

    }
}
