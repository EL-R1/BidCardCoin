using System.Windows;
using BidCardCoin.Views;

namespace BidCardCoin.Vue
{
    public partial class SecondaryWindow : Window
    {
        public SecondaryWindow()
        {
            InitializeComponent();
        }
        private void btnEnchere(object sender, RoutedEventArgs e)
        {
            Enchere ucObj = new Enchere();
            stkTest.Children.Clear();
            stkTest.Children.Add(ucObj);
        }
        private void btnLot(object sender, RoutedEventArgs e)
        {
            Lot ucObj = new Lot();
            stkTest.Children.Clear();
            stkTest.Children.Add(ucObj);
        }
        private void btnProduit(object sender, RoutedEventArgs e)
        {
            Produit ucObj = new Produit();
            stkTest.Children.Clear();
            stkTest.Children.Add(ucObj);
        }
    }
}