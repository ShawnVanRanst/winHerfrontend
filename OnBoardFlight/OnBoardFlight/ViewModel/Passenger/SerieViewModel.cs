using OnBoardFlight.Model;
using OnBoardFlight.Model.Helper;
using OnBoardFlight.Model.Media;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnBoardFlight.ViewModel.Passenger
{
    public class SerieViewModel
    {
        public List<Video> VideoList { get; set; }

        public ObservableCollection<CategoryAndListVideoHelper> CategoryListSerieList { get; set; }

        public SerieViewModel()
        {
            LoadData();
            VideoList = DummyDataSource.SerieList();
        }

        private async void LoadData()
        {

        }
    }
}
