using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using BidCardCoin.Crtl;
using BidCardCoin.ORM;
using BidCardCoin.Vue;

namespace BidCardCoin.Views
{
    public partial class Produit : UserControl
    {
        public Produit()
        {
            InitializeComponent();
            loadProduits();
        }
        ProduitViewModel myDataObject; // Objet de liaison avec la vue lors de l'ajout d'une Produit par exemple.
        ObservableCollection<ProduitViewModel> lp;
        int compteur = 0;
        int selectedProduitId;
        private void btnAjouter(object sender, RoutedEventArgs e)
        {
            Ajout_produit ucObj = new Ajout_produit();
            stkTest.Children.Clear();
            stkTest.Children.Add(ucObj);
        }
        
        void loadProduits()
        {
            lp = ProduitORM.listeProduits();
            myDataObject = new ProduitViewModel();
            //LIEN AVEC la VIEW
            listeProduits.ItemsSource = lp; // bind de la liste avec la source, permettant le binding.
        }

        private void listeCategories_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if ((listeProduits.SelectedIndex < lp.Count) && (listeProduits.SelectedIndex >= 0))
            {
                selectedProduitId = lp.ElementAt(listeProduits.SelectedIndex).id_produit;
            }
        }

        private void supprimerProduit(object sender, RoutedEventArgs e)
        {
            if (listeProduits.SelectedItem is ProduitViewModel)
            {
                ProduitViewModel toRemove = (ProduitViewModel)listeProduits.SelectedItem;
                lp.Remove(toRemove);
                listeProduits.Items.Refresh();
                ProduitORM.supprimerProduit(selectedProduitId);
            }
        }
    }
}