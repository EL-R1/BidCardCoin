using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using BidCardCoin.Crtl;
using BidCardCoin.DAL;
using BidCardCoin.ORM;

namespace BidCardCoin.Views
{
    public partial class Ajout_Vendeur : UserControl
    {
        public Ajout_Vendeur()
        {
            InitializeComponent();

            DALConnection.OpenConnection();
            
            loadVendeurs();

            loadPersonnes();
            
            loadProduits();

            appliquerContexte();

            gererEventSupplémentaires();
        }
        
        VendeurViewModel myDataObject; // Objet de liaison avec la vue lors de l'ajout d'une Vendeur par exemple.
        ObservableCollection<VendeurViewModel> lp;
        int compteur = 0;
        
        PersonneViewModel myDataObjectPersonne; // Objet de liaison avec la vue lors de l'ajout d'une Vendeur par exemple.
        ObservableCollection<PersonneViewModel> pe;
        
        ProduitViewModel myDataObjectProduit; // Objet de liaison avec la vue lors de l'ajout d'une Vendeur par exemple.
        ObservableCollection<ProduitViewModel> pr;
        
        void loadVendeurs()
        {
            lp = VendeurORM.listeVendeurs();
            myDataObject = new VendeurViewModel();
            //LIEN AVEC la VIEW
            /*listeVendeurs.ItemsSource = lp; // bind de la liste avec la source, permettant le binding.*/
        }
        
        void loadPersonnes()
        {
            pe = PersonneORM.listePersonnes();
            myDataObjectPersonne = new PersonneViewModel();
            ComboBoxPersonne.ItemsSource = pe;
            //LIEN AVEC la VIEW
            /*listeVendeurs.ItemsSource = lp; // bind de la liste avec la source, permettant le binding.*/
        }
        
        void loadProduits()
        {
            pr = ProduitORM.listeProduits();
            myDataObjectProduit = new ProduitViewModel();
            ComboBoxProduit.ItemsSource = pr;
            //LIEN AVEC la VIEW
            /*listeVendeurs.ItemsSource = lp; // bind de la liste avec la source, permettant le binding.*/
        }
        
        void appliquerContexte()
        {
            // Lien avec les textbox
            ComboBoxProduit.DataContext = myDataObject;
            ComboBoxPersonne.DataContext = myDataObject;
        }

        void gererEventSupplémentaires()
        {
        }
        
        private void btnReturn(object sender, RoutedEventArgs e)
        {
            Vendeur ucObj = new Vendeur();
            stkTest.Children.Clear();
            stkTest.Children.Add(ucObj);
        }
        private void btnAjouter(object sender, RoutedEventArgs e)
        {
            myDataObject.id = VendeurDAL.getMaxIdVendeur() + 1;

            lp.Add(myDataObject);
            VendeurORM.insertVendeur(myDataObject);
            compteur = lp.Count();

            // Comme on a inséré une Vendeur, on crée un nouvel objet VendeurViewModel
            // Et on réatache tout ce qu'il faut pour que la vue soit propre
            myDataObject = new VendeurViewModel();

            // Comme le contexte des élément de la vue est encore l'ancien VendeurViewModel,
            // On refait les liens entre age, slider, textbox, bouton et le nouveau VendeurViewModel
            ComboBoxProduit.DataContext = myDataObject;
            ComboBoxPersonne.DataContext = myDataObject;
        }
    }
}