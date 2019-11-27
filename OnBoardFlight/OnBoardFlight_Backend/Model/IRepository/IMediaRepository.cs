using OnBoardFlight_Backend.Model.MediaTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnBoardFlight_Backend.Model.IRepository
{
    public interface IMediaRepository
    {

        IEnumerable<Media> GetAllMedia();

        void SaveChanges();
    }
}
