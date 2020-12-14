using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using BidCardCoin.Crtl;
using System.Text.RegularExpressions;
using System.Windows.Input;
using BidCardCoin.DAL;
using BidCardCoin.ORM;

namespace BidCardCoin.Views
{
    public partial class Ajout_produit : UserControl
    {
        ProduitViewModel myDataObject; // Objet de liaison avec la vue lors de l'ajout d'une Produit par exemple.
        ObservableCollection<ProduitViewModel> lp;
        int compteur = 0;
        
        public Ajout_produit()
        {
            InitializeComponent();
            
            loadProduits();

            appliquerContexte();

            gererEventSupplémentaires();

            loadLots();
        }
        
        LotViewModel myDataObjectLot; // Objet de liaison avec la vue lors de l'ajout d'une Lot par exemple.
        ObservableCollection<LotViewModel> lot;

        void loadLots()
        {
            lot = LotORM.listeLots();
            myDataObjectLot = new LotViewModel();
            //LIEN AVEC la VIEW
            ComboBoxLot.ItemsSource = lp; // bind de la liste avec la source, permettant le binding.
        }
        private void btnReturn(object sender, RoutedEventArgs e)
        {
            Produit ucObj = new Produit();
            stkTest.Children.Clear();
            stkTest.Children.Add(ucObj);
        }
        private void FloatOnly(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex(@"/(?!0\d)\d*(\.\d+)?/");
            e.Handled = regex.IsMatch(e.Text);
        }
        private void BoolOnly(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-1]+");
            e.Handled = regex.IsMatch(e.Text);
        }
        
        
        private void btnAjouter(object sender, RoutedEventArgs e)
        {
            myDataObject.id = ProduitDAL.getMaxIdProduit() + 1;

            lp.Add(myDataObject);
            ProduitORM.insertProduit(myDataObject);
            compteur = lp.Count();

            // Comme on a inséré une Personne, on crée un nouvel objet PersonneViewModel
            // Et on réatache tout ce qu'il faut pour que la vue soit propre
            /*listeProduits.Items.Refresh();*/
            myDataObject = new ProduitViewModel();

            // Comme le contexte des élément de la vue est encore l'ancien PersonneViewModel,
            // On refait les liens entre age, slider, textbox, bouton et le nouveau PersonneViewModel
            ComboBoxLot.DataContext = myDataObject;
            prix_de_depart.DataContext = myDataObject;
            Description.DataContext = myDataObject;
            Date_Vente.DataContext = myDataObject;
            estimation.DataContext = myDataObject;
            is_vendu.DataContext = myDataObject;
            prix_reserve.DataContext = myDataObject;
            region.DataContext = myDataObject;
            attribut.DataContext = myDataObject;
        }
        
        void loadProduits()
        {
            lp = ProduitORM.listeProduits();
            myDataObject = new ProduitViewModel();
            //LIEN AVEC la VIEW
            /*listeProduits.ItemsSource = lp; // bind de la liste avec la source, permettant le binding.*/
        }
        
        void appliquerContexte()
        {
            /*// Lien avec les textbox
            nomTextBox.DataContext = myDataObject;
            prenomTextBox.DataContext = myDataObject;

            // Lien entre age-slider et bouton
            nomPrenomButton2.DataContext = myDataObject;
            // Lien entre age et slider
            txtAge.DataContext = myDataObject;
            txtAgeDeux.DataContext = myDataObject;
            mySlider.DataContext = myDataObject;*/
            
            ComboBoxLot.DataContext = myDataObject;
            prix_de_depart.DataContext = myDataObject;
            Description.DataContext = myDataObject;
            Date_Vente.DataContext = myDataObject;
            estimation.DataContext = myDataObject;
            is_vendu.DataContext = myDataObject;
            prix_reserve.DataContext = myDataObject;
            region.DataContext = myDataObject;
            attribut.DataContext = myDataObject;
        }

        void gererEventSupplémentaires()
        {
        }
        
        
        
        
    }
}