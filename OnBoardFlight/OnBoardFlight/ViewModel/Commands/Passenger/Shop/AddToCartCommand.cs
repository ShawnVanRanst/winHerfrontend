using OnBoardFlight.ViewModel.Passenger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace OnBoardFlight.ViewModel.Commands.Passenger.Shop
{
    public class AddToCartCommand : ICommand
    {

        public int ProductId { get; set; }

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
                ShopViewModel.AddToCart(ProductId);
            }
            catch(ArgumentException ex)
            {
                //Give a warning
            }
        }
    }
}
