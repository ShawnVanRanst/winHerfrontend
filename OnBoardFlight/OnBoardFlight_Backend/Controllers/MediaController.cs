using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnBoardFlight_Backend.Data.IRepository;
using OnBoardFlight_Backend.Model.MediaTypes;

namespace OnBoardFlight_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MediaController : ControllerBase
    {
        private readonly IMediaRepository _mediaRepo;

        public MediaController(IMediaRepository mediaRepository)
        {
            _mediaRepo = mediaRepository;
        }

        [HttpGet]
        [Route("api/media/media")]
        public IEnumerable<Media> GetAllMedia()
        {
            return _mediaRepo.GetAllMedia();
        }

        [HttpGet]
        [Route("api/media/movies")]
        public IEnumerable<Movie> GetAllMovies()
        {
            return _mediaRepo.GetAllMovies();
        }

        [HttpGet]
        [Route("api/media/series")]
        public IEnumerable<Serie> GetAllSeries()
        {
            return _mediaRepo.GetAllSeries();
        }

        [HttpGet]
        [Route("api/media/music")]
        public IEnumerable<Music> GetAllMusic()
        {
            return _mediaRepo.GetAllMusic();
        }

    }
}