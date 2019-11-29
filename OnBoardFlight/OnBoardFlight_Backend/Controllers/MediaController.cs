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
        public IEnumerable<Media> GetAllMedia()
        {
            return _mediaRepo.GetAllMedia();
        }

        [HttpGet]
        [Route("movies")]
        public IEnumerable<Media> GetAllMovies()
        {
            return _mediaRepo.GetAllMovies();
        }

        [HttpGet]
        [Route("series")]
        public IEnumerable<Media> GetAllSeries()
        {
            return _mediaRepo.GetAllSeries();
        }

        [HttpGet]
        [Route("music")]
        public IEnumerable<Media> GetAllMusic()
        {
            return _mediaRepo.GetAllMusic();
        }

    }
}