﻿using System.Windows;
using System.Windows.Controls;

namespace BidCardCoin.Views
{
    public partial class Lot : UserControl
    {
        public Lot()
        {
            InitializeComponent();
        }
        private void btnReturn(object sender, RoutedEventArgs e)
        {
            Lot ucObj = new Lot();
            stkTest.Children.Clear();
            stkTest.Children.Add(ucObj);
        }
        private void btnAjouter(object sender, RoutedEventArgs e)
        {
            Ajout_lot ucObj = new Ajout_lot();
            stkTest.Children.Clear();
            stkTest.Children.Add(ucObj);
        }
    }
}