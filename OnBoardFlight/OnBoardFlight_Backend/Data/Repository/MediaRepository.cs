using Microsoft.EntityFrameworkCore;
using OnBoardFlight.Data;
using OnBoardFlight_Backend.Model.IRepository;
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

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }
    }
}
