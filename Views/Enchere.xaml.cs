using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using BidCardCoin.Crtl;
using BidCardCoin.ORM;
using BidCardCoin.Views;

namespace BidCardCoin.Vue
{
    public partial class Enchere : UserControl
    {
        public Enchere()
        {
            InitializeComponent();
            loadEncheres();
        }
        EnchereViewModel myDataObject; // Objet de liaison avec la vue lors de l'ajout d'une Enchere par exemple.
        ObservableCollection<EnchereViewModel> lp;
        int compteur = 0;
        
        void loadEncheres()
        {
            lp = EnchereORM.listeEncheres();
            myDataObject = new EnchereViewModel();
            //LIEN AVEC la VIEW
            listeEncheres.ItemsSource = lp; // bind de la liste avec la source, permettant le binding.
        
        }
        private void btnAjouter(object sender, RoutedEventArgs e)
        {
            Ajout_enchere ucObj = new Ajout_enchere();
            stkTest.Children.Clear();
            stkTest.Children.Add(ucObj);
        }
    }
}