using OnBoardFlight.ViewModel.CabinCrew;
using OnBoardFlight.ViewModel.Passenger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace OnBoardFlight.ViewModel.Commands.CabinCrew.Promotion
{
    public class AddPromotionCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public AdvertismentViewModel AdvertismentViewModel { get; set; }

        public AddPromotionCommand(AdvertismentViewModel advertismentViewModel)
        {
            AdvertismentViewModel = advertismentViewModel;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            AddPromotion();
        }

        private async void AddPromotion()
        {
            await AdvertismentViewModel.EditPromotion();
        }
    }
}
