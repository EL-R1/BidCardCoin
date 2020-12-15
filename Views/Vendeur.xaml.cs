using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
 using BidCardCoin.Crtl;
 using BidCardCoin.ORM;
using System.Windows.Input;

 namespace BidCardCoin.Views
{
    public partial class Vendeur : UserControl
    {
        public Vendeur()
        {
            InitializeComponent();
            
            loadVendeurs();
        }
        
        VendeurViewModel myDataObject; // Objet de liaison avec la vue lors de l'ajout d'une Vendeur par exemple.
        ObservableCollection<VendeurViewModel> lp;
        int compteur = 0;
        int selectedVendeursId;
        
        void loadVendeurs()
        {
            lp = VendeurORM.listeVendeurs();
            myDataObject = new VendeurViewModel();
            //LIEN AVEC la VIEW
            listeVendeurs.ItemsSource = lp; // bind de la liste avec la source, permettant le binding.
        }
        private void btnAjouter(object sender, RoutedEventArgs e)
        {
            Ajout_Vendeur ucObj = new Ajout_Vendeur();
            stkTest.Children.Clear();
            stkTest.Children.Add(ucObj);
        }

        private void listeVendeurs_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if ((listeVendeurs.SelectedIndex < lp.Count) && (listeVendeurs.SelectedIndex >= 0))
            {
                selectedVendeursId = lp.ElementAt(listeVendeurs.SelectedIndex).id;
            }
        }

        private void supprimerVendeur(object sender, RoutedEventArgs e)
        {
            if (listeVendeurs.SelectedItem is VendeurViewModel)
            {
                VendeurViewModel toRemove = (VendeurViewModel)listeVendeurs.SelectedItem;
                lp.Remove(toRemove);
                listeVendeurs.Items.Refresh();
                VendeurORM.supprimerVendeur(selectedVendeursId);
            }
        }
    }
}