using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace OnBoardFlight.Model
{
    public class Chat : INotifyPropertyChanged
    {
        private int _id;

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }


        private string _name;

        public string Name
        {
            get { return _name; }
            set { _name = value; RaisePropertyChanged("Name"); }
        }

        private List<Passenger> _participants;

        public List<Passenger> Participants
        {
            get { return _participants; }
            set { _participants = value; RaisePropertyChanged("Participants"); }
        }

        private List<Message> _messages;

        public List<Message> Messages
        {
            get { return _messages; }
            set { _messages = value; RaisePropertyChanged("Messages"); }
        }

        public void AddParticipant(Passenger participant)
        {
            _participants.Add(participant);
        }

        public void AddMessage(Message message)
        {
            _messages.Add(message);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
