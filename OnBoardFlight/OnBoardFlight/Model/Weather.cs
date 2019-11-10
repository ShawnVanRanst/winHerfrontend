using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media.Imaging;

namespace OnBoardFlight.Model
{
    public class Weather : INotifyPropertyChanged
    {
        private BitmapImage _icon;

        public BitmapImage Icon
        {
            get { return _icon; }
            set { _icon = value; RaisePropertyChanged("Icon"); }
        }

        private int _temp;

        public int Temp
        {
            get { return _temp; }
            set { _temp = value; RaisePropertyChanged("MaxTemp"); }
        }

        private string _description;

        public string Description
        {
            get { return _description; }
            set { _description = value; RaisePropertyChanged("Description"); }
        }

        private double _windSpeed;

        public double WindSpeed
        {
            get { return _windSpeed; }
            set { _windSpeed = value; RaisePropertyChanged("WindSpeed"); }
        }

        private double _windOrientation;

        public double WindOrientation
        {
            get { return _windOrientation; }
            set { _windOrientation = value; RaisePropertyChanged("WindOrientation"); }
        }

        private string _when;

        public string When
        {
            get { return _when; }
            set { _when = value; RaisePropertyChanged("When"); }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void RaisePropertyChanged([CallerMemberName]string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
