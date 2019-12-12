using Newtonsoft.Json;
using OnBoardFlight.Model;
using OnBoardFlight.Model.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Web.Http;

namespace OnBoardFlight.ViewModel.CabinCrew
{
    public class NavigationCabinCrewViewModel
    {
        public Model.CabinCrew CabinCrew { get; set; }

        public NavigationCabinCrewViewModel(CabinCrewLogin cabinCrewLogin)
        {
            LoadData(cabinCrewLogin);
        }

        public async void LoadData(CabinCrewLogin cabinCrewLogin)
        {
            var cabinCrewJson = JsonConvert.SerializeObject(cabinCrewLogin);
            HttpClient client = new HttpClient();
            var res = await client.PostAsync(new Uri("http://localhost:5000/api/User/cabincrew/login"), new HttpStringContent(cabinCrewJson, Windows.Storage.Streams.UnicodeEncoding.Utf8, "application/json"));

            if (res.IsSuccessStatusCode)
            {
                CabinCrew = JsonConvert.DeserializeObject<Model.CabinCrew>(res.Content.ToString());
            }
        }
    }
}
