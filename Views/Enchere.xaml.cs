using System.Windows;
using System.Windows.Controls;
using BidCardCoin.Views;

namespace BidCardCoin.Vue
{
    public partial class Enchere : UserControl
    {
        public Enchere()
        {
            InitializeComponent();
        }
        private void btnLogout(object sender, RoutedEventArgs e)
        {
            Login ucObj = new Login();
            stkTest.Children.Clear();
            stkTest.Children.Add(ucObj);
        }
        private void btnAjout_enchere(object sender, RoutedEventArgs e)
        {
            Ajout_enchere ucObj = new Ajout_enchere();
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