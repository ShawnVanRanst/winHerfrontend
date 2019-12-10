using OnBoardFlight.ViewModel.Passenger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace OnBoardFlight.ViewModel.Commands.Media
{
    public class MusicListLoadDataCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public MusicListViewModel MusicListViewModel { get; set; }

        public MusicListLoadDataCommand(MusicListViewModel mlvm)
        {
            MusicListViewModel = mlvm;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            throw new NotImplementedException();
        }
    }
}
