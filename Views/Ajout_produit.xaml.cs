using System.Windows;
using System.Windows.Controls;

namespace BidCardCoin.Views
{
    public partial class Ajout_produit : UserControl
    {
        public Ajout_produit()
        {
            InitializeComponent();
        }
        private void btnReturn(object sender, RoutedEventArgs e)
        {
            Produit ucObj = new Produit();
            stkTest.Children.Clear();
            stkTest.Children.Add(ucObj);
        }
        private void btnAjouter(object sender, RoutedEventArgs e)
        {
            Produit ucObj = new Produit();
            stkTest.Children.Clear();
            stkTest.Children.Add(ucObj);
        }
    }
}