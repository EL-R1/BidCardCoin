using System.Windows;
using System.Windows.Controls;
using BidCardCoin.Vue;

namespace BidCardCoin.Views
{
    public partial class Ajout_enchere : UserControl
    {
        public Ajout_enchere()
        {
            InitializeComponent();
        }
        private void btnReturn(object sender, RoutedEventArgs e)
        {
            Enchere ucObj = new Enchere();
            stkTest.Children.Clear();
            stkTest.Children.Add(ucObj);
        }
        private void btnAjouter(object sender, RoutedEventArgs e)
        {
            Enchere ucObj = new Enchere();
            stkTest.Children.Clear();
            stkTest.Children.Add(ucObj);
        }
    }
}