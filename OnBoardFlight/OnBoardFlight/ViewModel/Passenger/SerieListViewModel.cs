using Newtonsoft.Json;
using OnBoardFlight.Model;
using OnBoardFlight.Model.Helper;
using OnBoardFlight.Model.Media;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace OnBoardFlight.ViewModel.Passenger
{
    public class SerieListViewModel
    {
        public List<Video> VideoList { get; set; }

        public ObservableCollection<CategoryAndListVideoHelper> CategoryListSerieList { get; set; }

        public SerieListViewModel()
        {
            CategoryListSerieList = new ObservableCollection<CategoryAndListVideoHelper>();
            VideoList = new List<Video>();
            LoadData();
        }
        private void FillCategoryListVideoList()
        {
            var categories = Enum.GetValues(typeof(VideoCategory));
            foreach (VideoCategory category in categories)
            {
                CategoryAndListVideoHelper categoryAndListVideoHelper = new CategoryAndListVideoHelper()
                {
                    Category = category,
                    VideoList = new List<Video>()
                };
                foreach (Video v in VideoList)
                {
                    if (v.Category == category)
                    {
                        categoryAndListVideoHelper.VideoList.Add(v);
                    }
                }
                CategoryListSerieList.Add(categoryAndListVideoHelper);
            }
        }

        private async void LoadData()
        {
            HttpClient client = new HttpClient();
            var json = await client.GetStringAsync(new Uri("http://localhost:5000/api/Media/series"));
            var serielist = JsonConvert.DeserializeObject<IList<Movie>>(json);
            foreach (var serie in serielist)
            {
                VideoList.Add(serie);
            }
            FillCategoryListVideoList();
        }
    }
}
