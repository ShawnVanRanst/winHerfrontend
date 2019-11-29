using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnBoardFlight_Backend.Model.MediaTypes
{
    public abstract class Media
    {
        #region Properties

        public int MediaId { get; set; }

        public string DisplayImage { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        #endregion

        #region Constructors

        public Media()
        {

        }

        public Media(string displayImage, string title, string description)
        {
            DisplayImage = displayImage;
            Title = title;
            Description = description;
        }


        #endregion

    }
}
