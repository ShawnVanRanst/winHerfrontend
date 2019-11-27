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

        public DateTime SendDate { get; set; }

        public Passenger Sender { get; set; }


        #endregion

        #region Constructors

        public Message()
        {

        }

        public Message(DateTime sendDate, Passenger sender)
        {
            SendDate = sendDate;
            Sender = sender;
        }


        #endregion
    }
}
