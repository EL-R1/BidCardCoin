using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using BidCardCoin.Crtl;
using BidCardCoin.DAL;
using BidCardCoin.ORM;

namespace BidCardCoin.Views
{
    public partial class Ajout_categorie : UserControl
    {
        public Ajout_categorie()
        {
            InitializeComponent();

            DALConnection.OpenConnection();
            
            loadCategories();

            appliquerContexte();

            gererEventSupplémentaires();
        }
        
        CategorieViewModel myDataObject; // Objet de liaison avec la vue lors de l'ajout d'une Categorie par exemple.
        ObservableCollection<CategorieViewModel> lp;
        int compteur = 0;
        
        void loadCategories()
        {
            lp = CategorieORM.listeCategories();
            myDataObject = new CategorieViewModel();
            //LIEN AVEC la VIEW
            /*listeCategories.ItemsSource = lp; // bind de la liste avec la source, permettant le binding.*/
        
        }
        
        void appliquerContexte()
        {
            // Lien avec les textbox
            nom.DataContext = myDataObject;
        }

        void gererEventSupplémentaires()
        {
        }
        
        private void btnReturn(object sender, RoutedEventArgs e)
        {
            Categorie ucObj = new Categorie();
            stkTest.Children.Clear();
            stkTest.Children.Add(ucObj);
        }
        private void btnAjouter(object sender, RoutedEventArgs e)
        {
            myDataObject.id_categorie = CategorieDAL.getMaxIdCategorie() + 1;

            lp.Add(myDataObject);
            CategorieORM.insertCategorie(myDataObject);
            compteur = lp.Count();

            // Comme on a inséré une Categorie, on crée un nouvel objet CategorieViewModel
            // Et on réatache tout ce qu'il faut pour que la vue soit propre
            myDataObject = new CategorieViewModel();

            // Comme le contexte des élément de la vue est encore l'ancien CategorieViewModel,
            // On refait les liens entre age, slider, textbox, bouton et le nouveau CategorieViewModel
            nom.DataContext = myDataObject;
        }
    }
}