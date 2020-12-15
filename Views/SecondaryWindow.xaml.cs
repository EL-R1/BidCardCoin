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
        private void btnPersonne(object sender, RoutedEventArgs e)
        {
            Personne ucObj = new Personne();
            stkTest.Children.Clear();
            stkTest.Children.Add(ucObj);
        }
        private void btnAcheteur(object sender, RoutedEventArgs e)
        {
            Acheteur ucObj = new Acheteur();
            stkTest.Children.Clear();
            stkTest.Children.Add(ucObj);
        }
        private void btnVendeur(object sender, RoutedEventArgs e)
        {
            Vendeur ucObj = new Vendeur();
            stkTest.Children.Clear();
            stkTest.Children.Add(ucObj);
        }
        
        private void btnCommissaire_Priseur(object sender, RoutedEventArgs e)
        {
            Commissaire_Priseur ucObj = new Commissaire_Priseur();
            stkTest.Children.Clear();
            stkTest.Children.Add(ucObj);
        }
        private void btnOrdre_Achat(object sender, RoutedEventArgs e)
        {
            Ordre_Achat ucObj = new Ordre_Achat();
            stkTest.Children.Clear();
            stkTest.Children.Add(ucObj);
        }
        
        private void btnExit(object sender, RoutedEventArgs routedEventArgs)
        {
            this.Close();
        }
    }
}