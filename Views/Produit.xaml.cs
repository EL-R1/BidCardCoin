using System.Windows;
using System.Windows.Controls;
using BidCardCoin.Vue;

namespace BidCardCoin.Views
{
    public partial class Produit : UserControl
    {
        public Produit()
        {
            InitializeComponent();
        }
        private void btnAjouter(object sender, RoutedEventArgs e)
        {
            Ajout_produit ucObj = new Ajout_produit();
            stkTest.Children.Clear();
            stkTest.Children.Add(ucObj);
        }
        
    }
}