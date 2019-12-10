using Newtonsoft.Json;
using OnBoardFlight.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace OnBoardFlight.ViewModel.Passenger
{
    public class ChatViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Chat> ChatList { get; set; }

        public Model.Passenger Passenger { get; set; }

        public ChatViewModel(Model.Passenger passenger)
        {
            Passenger = passenger;
            ChatList = new ObservableCollection<Chat>(passenger.ChatList);
            LoadDataAsync();
        }

        private async void LoadDataAsync()
        {
            HttpClient client = new HttpClient();
            var json = await client.GetStringAsync(new Uri("https://localhost:5000/api/passenger"));
            Passenger = JsonConvert.DeserializeObject<Model.Passenger>(json);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void RaisePropertyChanged([CallerMemberName]string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
