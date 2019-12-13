using OnBoardFlight.ViewModel.Passenger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Xaml.Controls;

namespace OnBoardFlight.ViewModel.Commands.Passenger.Shop
{
    public class AddToCartCommand<T> : ICommand
    {
        public ShopViewModel ShopViewModel{ get; set; }

        public AddToCartCommand(ShopViewModel svm)
        {
            ShopViewModel = svm;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            try
            {
                ShopViewModel.AddProductToCart();
            }
            catch(ArgumentException ex)
            {
                //Give a warning
            }
        }
    }
}
