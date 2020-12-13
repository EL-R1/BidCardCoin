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
        private void btnLogout(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            this.Close();
            //App.Current.Windows[0].Close();
            mainWindow.Show();
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
        private void btnCategorie(object sender, RoutedEventArgs e)
        {
            Categorie ucObj = new Categorie();
            stkTest.Children.Clear();
            stkTest.Children.Add(ucObj);
        }
        private void btnLieu(object sender, RoutedEventArgs e)
        {
            Lieu ucObj = new Lieu();
            stkTest.Children.Clear();
            stkTest.Children.Add(ucObj);
        }
        
        private void btnExit(object sender, RoutedEventArgs routedEventArgs)
        {
            this.Close();
        }
    }
}