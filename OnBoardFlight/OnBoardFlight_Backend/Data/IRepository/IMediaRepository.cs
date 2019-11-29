using OnBoardFlight_Backend.Model.MediaTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnBoardFlight_Backend.Data.IRepository
{
    public interface IMediaRepository
    {

        IEnumerable<Media> GetAllMedia();

        IEnumerable<Movie> GetAllMovies();

        IEnumerable<Music> GetAllMusic();

        IEnumerable<Serie> GetAllSeries();

        void SaveChanges();
    }
}
