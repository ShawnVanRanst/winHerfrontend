using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnBoardFlight_Backend.Model.MediaTypes
{
    public class Video: Media
    {

        public VideoCategory Category { get; set; }

        public Video()
        {

        }

        public Video(VideoCategory category)
        {
            Category = category;
        }
    }
}
