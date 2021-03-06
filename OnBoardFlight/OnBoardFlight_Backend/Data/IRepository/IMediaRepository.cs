﻿using OnBoardFlight_Backend.Model.MediaTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnBoardFlight_Backend.Data.IRepository
{
    public interface IMediaRepository
    {

        IEnumerable<Media> GetAllMedia();

        IEnumerable<Media> GetAllMovies();

        IEnumerable<Media> GetAllMusic();

        IEnumerable<Media> GetAllSeries();

        Movie GetMovieById(int id);

        Serie GetSerieById(int id);

        Music GetMusicById(int id);

        SerieEpisode GetSerieEpisodeById(int id);

        void SaveChanges();
    }
}
