﻿using OnBoardFlight.Model.Helper;
using OnBoardFlight.ViewModel.Passenger;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace OnBoardFlight.View.Passenger
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Shop : Page
    {

        public Shop()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            if(this.DataContext.GetType() != typeof(ShopViewModel))
            {
                this.DataContext = new ShopViewModel((GeneralLogin)e.Parameter);
            }
        }

        private void SelectProduct(object sender, TappedRoutedEventArgs e)
        {
            ListView lv = (ListView) sender;
            Model.Product product = (Model.Product)lv.SelectedItem;
            (this.DataContext as ShopViewModel).Product = product;
            (this.DataContext as ShopViewModel).AddProductToCart();
        }

        private void AddOrder(object sender, TappedRoutedEventArgs e)
        {
            (this.DataContext as ShopViewModel).AddOrder();
        }

        private void SelectOrderline(object sender, TappedRoutedEventArgs e)
        {
            ListView lv = (ListView)sender;
            Model.Orderline ol = (Model.Orderline)lv.SelectedItem;
            (this.DataContext as ShopViewModel).Orderline = ol;
        }

        private void DeleteOrderline(object sender, TappedRoutedEventArgs e)
        {
            (this.DataContext as ShopViewModel).DeleteOrderline();
        }
    }
}
