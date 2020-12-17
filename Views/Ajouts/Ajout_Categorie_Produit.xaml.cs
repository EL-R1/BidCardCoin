using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using BidCardCoin.Crtl;
using BidCardCoin.DAL;
using BidCardCoin.ORM;

namespace BidCardCoin.Views
{
    public partial class Ajout_CategorieProduit : UserControl
    {
        public Ajout_CategorieProduit()
        {
            InitializeComponent();

            DALConnection.OpenConnection();
            
            loadCategorieProduits();
            
            loadProduits();
            
            loadCategories();
            
            appliquerContexte();

            gererEventSupplémentaires();
        }
        
        CategorieProduitViewModel myDataObject; // Objet de liaison avec la vue lors de l'ajout d'une CategorieProduit par exemple.
        ObservableCollection<CategorieProduitViewModel> cp;
        
        ProduitViewModel myDataObjectProduit; // Objet de liaison avec la vue lors de l'ajout d'une CategorieProduit par exemple.
        ObservableCollection<ProduitViewModel> pr;
        
        CategorieViewModel myDataObjectCategorie; // Objet de liaison avec la vue lors de l'ajout d'une CategorieProduit par exemple.
        ObservableCollection<CategorieViewModel> ca;
        int compteur = 0;
        
        void loadCategorieProduits()
        {
            cp = CategorieProduitORM.listeCategorieProduits();
            myDataObject = new CategorieProduitViewModel();
            //LIEN AVEC la VIEW
            /*listeCategorieProduits.ItemsSource = lp; // bind de la liste avec la source, permettant le binding.*/
        }
        
        void loadProduits()
        {
            pr = ProduitORM.listeProduits();
            myDataObjectProduit = new ProduitViewModel();
            ComboBoxProduit.ItemsSource = pr;
            //LIEN AVEC la VIEW
            /*listeAchats.ItemsSource = lp; // bind de la liste avec la source, permettant le binding.*/
        }
        
        void loadCategories()
        {
            ca = CategorieORM.listeCategories();
            myDataObjectCategorie = new CategorieViewModel();
            ComboBoxCategorie.ItemsSource = ca;
            //LIEN AVEC la VIEW
            /*listeAchats.ItemsSource = lp; // bind de la liste avec la source, permettant le binding.*/
        }

        private void btnReturn(object sender, RoutedEventArgs e)
        {
            Produit ucObj = new Produit();
            stkTest.Children.Clear();
            stkTest.Children.Add(ucObj);
        }
        void appliquerContexte()
        {
            // Lien avec les textbox
            ComboBoxProduit.DataContext = myDataObject;
            ComboBoxCategorie.DataContext = myDataObject;
        }

        void gererEventSupplémentaires()
        {
        }
        
        private void btnAjouter(object sender, RoutedEventArgs e)
        {
            cp.Add(myDataObject);
            CategorieProduitORM.insertCategorieProduit(myDataObject);
            compteur = cp.Count();

            // Comme on a inséré une CategorieProduit, on crée un nouvel objet CategorieProduitViewModel
            // Et on réatache tout ce qu'il faut pour que la vue soit propre
            myDataObject = new CategorieProduitViewModel();

            // Comme le contexte des élément de la vue est encore l'ancien CategorieProduitViewModel,
            // On refait les liens entre age, slider, textbox, bouton et le nouveau CategorieProduitViewModel
            ComboBoxProduit.DataContext = myDataObject;
            ComboBoxCategorie.DataContext = myDataObject;
        }
    }
}