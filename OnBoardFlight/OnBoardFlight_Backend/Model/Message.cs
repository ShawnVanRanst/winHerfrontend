using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnBoardFlight_Backend.Model
{
    public class Message
    {

        #region Properties

        public int MessageId { get; set; }

        public string Content { get; set; }

        public DateTime SendDate { get; set; }

        public Passenger Sender { get; set; }


        #endregion

        #region Constructors

        public Message()
        {

        }

        public Message(Passenger sender, string content)
        {
            Content = content;
            Sender = sender;
            SendDate = DateTime.UtcNow;
        }


        #endregion
    }
}
