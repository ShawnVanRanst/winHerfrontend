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
    public class VideoListViewModel
    {
        public string Type { get; set; }

        public List<Video> VideoList { get; set; }

        public ObservableCollection<CategoryAndListVideoHelper> CategoryListVideoList { get; set; }

        public VideoListViewModel(string type)
        {
            CategoryListVideoList = new ObservableCollection<CategoryAndListVideoHelper>();
            VideoList = new List<Video>();
            Type = type;
            LoadData();
            FillCategoryListVideoList();
        }

        // Get all the data (movie or serie) depending on type
        private void LoadData()
        {
            if (Type.Equals("movies"))
            {
                VideoList = DummyDataSource.MovieList();
            }
            if (Type.Equals("series"))
            {
                VideoList = DummyDataSource.SerieList();
            }
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
                CategoryListVideoList.Add(categoryAndListVideoHelper);
            }
        }
    }
}
