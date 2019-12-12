using Newtonsoft.Json;
using OnBoardFlight.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace OnBoardFlight.ViewModel.Passenger
{
    public class NavigationPassengerViewModel
    {
        public Model.Passenger Passenger { get; set; }

        public NavigationPassengerViewModel(string login)
        {
            GetData(login);
        }

        private async void GetData(string number)
        {
            HttpClient client = new HttpClient();
            try
            {
                var json = await client.GetStringAsync(new Uri("http://localhost:5000/api/User/passenger/" + number));
                var passenger = JsonConvert.DeserializeObject<Model.Passenger>(json);
                Passenger = passenger;
            }
            catch (Exception e)
            {
            };
        }
    }
}
