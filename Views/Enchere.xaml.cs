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
            MainWindow mainWindow = new MainWindow();
            App.Current.Windows[0].Close();
            mainWindow.Show();
        }
        private void btnAjout_enchere(object sender, RoutedEventArgs e)
        {
            Ajout_enchere ucObj = new Ajout_enchere();
            stkTest.Children.Clear();
            stkTest.Children.Add(ucObj);
        }
    }
}