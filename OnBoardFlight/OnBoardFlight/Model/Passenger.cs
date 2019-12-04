using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace OnBoardFlight.Model
{
    public class Passenger : User, INotifyPropertyChanged
    {
        private string _firstName;

        public string FirstName
        {
            get { return _firstName; }
            set { _firstName = value; RaisePropertyChanged("FirstName"); }
        }

        private string _lastName;

        public string LastName
        {
            get { return _lastName; }
            set { _lastName = value; RaisePropertyChanged("LastName"); }
        }

        private List<Passenger> _travelCompany;

        public List<Passenger> TravelCompany
        {
            get { return _travelCompany; }
            set { _travelCompany = value; RaisePropertyChanged("TravelCompany"); }
        }

        private List<Chat> _chatList;

        public List<Chat> ChatList
        {
            get { return _chatList; }
            set { _chatList = value; RaisePropertyChanged("ChatList"); }
        }

        private List<Notification> notifications;

        public List<Notification> Notifications
        {
            get { return notifications; }
            set { notifications = value; }
        }


        public void AddTravelCompanion(Passenger companion)
        {
            _travelCompany.Add(companion);
        }

        public void AddChat(Chat chat)
        {
            _chatList.Add(chat);
        }

        // Adds new member to list of travel company and create a chat with that member
        public void AddTravelCompanionWithChat(Passenger companion)
        {
            AddTravelCompanion(companion);

            Chat chat = new Chat()
            {
                Messages = new List<Message>(),
                Name = companion.FirstName + " " + companion.LastName,
                Participants = new List<Passenger>()
            };
            chat.AddParticipant(this);
            chat.AddParticipant(companion);
            AddChat(chat);

            companion.AddTravelCompanion(this);
            companion.AddChat(chat);
        }

        // Adds a self made chat to his chat list existing of travel company members
        public void AddTravelCompanyChat(List<Passenger> chatMembers, string chatName)
        {
            Chat chat = new Chat()
            {
                Messages = new List<Message>(),
                Name = chatName,
                Participants = chatMembers
            };

            AddChat(chat);

            chatMembers.ForEach(m => m.AddChat(chat));
        }
    }
}
