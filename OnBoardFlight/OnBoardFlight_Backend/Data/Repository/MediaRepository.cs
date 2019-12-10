using Microsoft.EntityFrameworkCore;
using OnBoardFlight.Data;
using OnBoardFlight_Backend.Data.IRepository;
using OnBoardFlight_Backend.Model.MediaTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnBoardFlight_Backend.Data.Repository
{
    public class MediaRepository : IMediaRepository
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly DbSet<Media> _mediafiles;

        public MediaRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            _mediafiles = _dbContext.Mediafiles;
        }

        public IEnumerable<Media> GetAllMedia()
        {
            return _mediafiles.ToList().OrderBy(m => m.Title);
        }

        public IEnumerable<Media> GetAllMovies()
        {
            return _mediafiles.Where(m => m.GetType() == typeof(Movie)).ToList();
        }

        public IEnumerable<Media> GetAllMusic()
        {
            return _mediafiles.Where(m => m.GetType() == typeof(Music)).ToList();
        }

        public IEnumerable<Media> GetAllSeries()
        {
            return _mediafiles.Where(m => m.GetType() == typeof(Serie)).ToList();
        }

        public Movie GetMovieById(int id)
        {
            return (Movie)_mediafiles.FirstOrDefault(m => m.Id == id);
        }

        public Music GetMusicById(int id)
        {
            return (Music)_mediafiles.FirstOrDefault(m => m.Id == id);
        }

        public Serie GetSerieById(int id)
        {
            return (Serie)_mediafiles.Include(s => (s as Serie).Episodes).FirstOrDefault(s => s.Id == id);
        }

        public SerieEpisode GetSerieEpisodeById(int id)
        {
            return (SerieEpisode)_mediafiles.FirstOrDefault(se => se.Id == id);
        }

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }
    }
}
