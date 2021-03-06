﻿using OnBoardFlight.ViewModel.CabinCrew;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace OnBoardFlight.ViewModel.Commands.CabinCrew
{
    public class SearchPassengerToMoveCommand : ICommand
    {
        public SeatViewModel SeatViewModel { get; set; }
        private int Passenger { get; set; }

        public SearchPassengerToMoveCommand(SeatViewModel svm, int p)
        {
            SeatViewModel = svm;
            Passenger = p;
        }


        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            SeatViewModel.SearchPassengerToMove(Passenger);
        }
    }
}
