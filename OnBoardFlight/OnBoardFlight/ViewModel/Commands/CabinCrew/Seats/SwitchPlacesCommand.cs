using OnBoardFlight.ViewModel.CabinCrew;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace OnBoardFlight.ViewModel.Commands
{
    public class SwitchPlacesCommand : ICommand
    {

        public SeatViewModel SeatViewModel { get; set; }


        public SwitchPlacesCommand(SeatViewModel svm)
        {
                SeatViewModel = svm;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            SeatViewModel.SwitchSeats();
        }
    }
}
