using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media.Imaging;

namespace OnBoardFlight.Model.Media
{
    public class Media : INotifyPropertyChanged
    {
        private int _id;

        public int Id
        {
            get { return _id; }
            set { _id = value; RaisePropertyChanged("Id"); }
        }

        private string _displayImage;

        public string DisplayImage
        {
            get { return _displayImage; }
            set {
                _displayImage = value;
                RaisePropertyChanged("DisplayImage");
            }
        }

        private string _title;

        public string Title
        {
            get { return _title; }
            set { _title = value; RaisePropertyChanged("Title"); }
        }

        private string _description;

        public string Description
        {
            get { return _description; }
            set { _description = value; RaisePropertyChanged("Description"); }
        }

        public BitmapImage Image
        {
            get {
                return new BitmapImage(new Uri("ms-appx:///Assets/" + DisplayImage));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
