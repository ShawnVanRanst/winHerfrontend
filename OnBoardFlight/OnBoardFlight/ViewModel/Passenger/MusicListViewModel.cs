using OnBoardFlight.Model;
using OnBoardFlight.Model.Helper;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnBoardFlight.ViewModel.Passenger
{
    public class MusicListViewModel
    {
        public List<Music> MusicList { get; set; }

        public ObservableCollection<CategoryAndListMusicHelper> CategoryListMusicList { get; set; }

        public MusicListViewModel()
        {
            CategoryListMusicList = new ObservableCollection<CategoryAndListMusicHelper>();
            MusicList = new List<Music>();
            MusicList = DummyDataSource.MusicList();
            FillCategoryListMusicList();
        }

        private void FillCategoryListMusicList()
        {
            var categories = Enum.GetValues(typeof(MusicCategory));
            foreach(MusicCategory category in categories)
            {
                CategoryAndListMusicHelper categoryAndListMusicHelper = new CategoryAndListMusicHelper()
                {
                    Category = category,
                    MusicList = new List<Music>()
                };
                foreach(Music m in MusicList)
                {
                    if(m.Category == category)
                    {
                        categoryAndListMusicHelper.MusicList.Add(m);
                    }
                }
                CategoryListMusicList.Add(categoryAndListMusicHelper);
            }
        }
    }
}
