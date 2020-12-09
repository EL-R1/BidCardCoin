using System.Windows;
using System.Windows.Controls;

namespace BidCardCoin.Views
{
    public partial class Ajout_lot : UserControl
    {
        public Ajout_lot()
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
            Lot ucObj = new Lot();
            stkTest.Children.Clear();
            stkTest.Children.Add(ucObj);
        }
    }
}