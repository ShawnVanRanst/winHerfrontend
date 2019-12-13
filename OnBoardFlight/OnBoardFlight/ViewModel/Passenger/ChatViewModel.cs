using Newtonsoft.Json;
using OnBoardFlight.Model;
using OnBoardFlight.Model.Helper;
using OnBoardFlight.ViewModel.Commands.Passenger.Chat;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Windows.Web.Http;
using HttpClient = Windows.Web.Http.HttpClient;

namespace OnBoardFlight.ViewModel.Passenger
{
    public class ChatViewModel : INotifyPropertyChanged
    {
        private Chat SelectedChat { get; set; }
        private string Seat { get; set; }

        public SendMessageCommand SendMessageCommand { get; set; }

        public ObservableCollection<Chat> ChatList { get; set; }

        private ObservableCollection<Message> _messages;

        public ObservableCollection<Message> Messages
        {
            get { return _messages; }
            set {
                _messages = value;
                RaisePropertyChanged("Messages"); }
        }

        private SendMessage _message;

        public SendMessage SendMessage
        {
            get { return _message; }
            set { _message = value; RaisePropertyChanged("SendMessage"); }
        }

        public HttpClient Client { get; set; }

        public Model.Passenger Passenger { get; set; }

        public ChatViewModel(GeneralLogin generalLogin)
        {
            Seat = generalLogin.Login;
            SendMessage = new SendMessage() { Content = "", Seat = Seat };
            SendMessageCommand = new SendMessageCommand(this);
            ChatList = new ObservableCollection<Chat>();
            Client = new HttpClient();
            LoadChat();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void RaisePropertyChanged([CallerMemberName]string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public async void SendAMessage()
        {
            try
            {
                SendMessage.Id = SelectedChat.Id;
                var MessageJson = JsonConvert.SerializeObject(SendMessage);
                var res = await Client.PostAsync(new Uri("http://localhost:5000/api/Chat"), new HttpStringContent(MessageJson, Windows.Storage.Streams.UnicodeEncoding.Utf8, "application/json"));
                if (res.IsSuccessStatusCode)
                {
                    SendMessage.Content = "";
                }
            }
            catch (Exception) { }
        }

        private async void LoadChat()
        {
            var json1 = await Client.GetStringAsync(new Uri("http://localhost:5000/api/User/passenger/chat/" + Seat));
            IList<Chat> chats = JsonConvert.DeserializeObject<IList<Chat>>(json1);
            chats.OrderBy(c => c.Name);
            foreach(var chat in chats)
            {
                ChatList.Add(chat);
            }

            int x = 0;
            IList<Chat> chatlist = new List<Chat>();
            while (true)
            {
                bool update = false;
                var json = await Client.GetStringAsync(new Uri("http://localhost:5000/api/User/passenger/chat/" + Seat));
                IList<Chat> chatlistFromApi = JsonConvert.DeserializeObject<IList<Chat>>(json);
                chatlistFromApi.OrderBy(c => c.Name);

                int lenght = chatlist.Count();
                if(chatlistFromApi.Count() == lenght){
                    if (chatlistFromApi.Count() != 0)
                    {
                        if (chatlist.Count() != 0)
                        {
                            for (int i = 0; i < lenght; i++)
                            {
                                if (CompareLists(chatlist[i].Messages, chatlistFromApi[i].Messages))
                                {
                                    update = true;
                                    break;
                                }
                            }
                        }
                        else
                        {
                            update = true;
                        }
                    }
                }
                else
                {
                    update = true;
                }

                if (update)
                {
                    chatlist = chatlistFromApi;
                    for(int i = 0; i < ChatList.Count(); i++)
                    {
                        List<Message> newMessages = chatlist[i].Messages;
                        ChatList[i].Messages = newMessages;
                        if(SelectedChat != null)
                        ShowMessages(SelectedChat);
                    }
                }
                Thread.SpinWait(5000);
            }
        }

        public void ShowMessages(Chat chat)
        {
            SelectedChat = chat;
            List<Message> messages = chat.Messages;
            ShowMessages(chat.Messages);
        }

        private void ShowMessages(List<Message> messages)
        {
            Messages = new ObservableCollection<Message>();
            foreach (var message in messages)
            {
                Messages.Add(message);
            }
        }

        private static bool CompareLists<Message>(List<Message> aListA, List<Message> aListB)
        {
            if (aListA.Count == aListB.Count)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
