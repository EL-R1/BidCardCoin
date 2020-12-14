using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using BidCardCoin.Crtl;
using BidCardCoin.ORM;

namespace BidCardCoin.Views
{
    public partial class Categorie : UserControl
    {
        public Categorie()
        {
            InitializeComponent();
            
            loadCategories();
        }
        
        CategorieViewModel myDataObject; // Objet de liaison avec la vue lors de l'ajout d'une Categorie par exemple.
        ObservableCollection<CategorieViewModel> lp;
        int compteur = 0;
        int selectedCategorieId;
        
        void loadCategories()
        {
            lp = CategorieORM.listeCategories();
            myDataObject = new CategorieViewModel();
            //LIEN AVEC la VIEW
            listeCategories.ItemsSource = lp; // bind de la liste avec la source, permettant le binding.
        }

        private void listeCategories_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if ((listeCategories.SelectedIndex < lp.Count) && (listeCategories.SelectedIndex >= 0))
            {
                selectedCategorieId = (lp.ElementAt<CategorieViewModel>(listeCategories.SelectedIndex)).id_categorie;
            }
        }

        private void btnAjouter(object sender, RoutedEventArgs e)
        {
            Ajout_categorie ucObj = new Ajout_categorie();
            stkTest.Children.Clear();
            stkTest.Children.Add(ucObj);
        }
    }
}