using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using BidCardCoin.Crtl;
using BidCardCoin.ORM;

namespace BidCardCoin.Views
{
    public partial class Lieu : UserControl
    {
        public Lieu()
        {
            InitializeComponent();
            
            loadLieux();
        }
        
        LieuViewModel myDataObject; // Objet de liaison avec la vue lors de l'ajout d'une Lieu par exemple.
        ObservableCollection<LieuViewModel> lp;
        int compteur = 0;
        int selectedLieuId;
        private object selectedLieuxId;

        void loadLieux()
        {
            lp = LieuORM.listeLieux();
            myDataObject = new LieuViewModel();
            //LIEN AVEC la VIEW
            listeLieux.ItemsSource = lp; // bind de la liste avec la source, permettant le binding.
        }
        private void btnAjouter(object sender, RoutedEventArgs e)
        {
            Ajout_Lieu ucObj = new Ajout_Lieu();
            stkTest.Children.Clear();
            stkTest.Children.Add(ucObj);
        }

        private void listeLieux_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if ((listeLieux.SelectedIndex < lp.Count) && (listeLieux.SelectedIndex >= 0))
            {
                selectedLieuxId = lp.ElementAt(listeLieux.SelectedIndex).id;
            }
        }

        private void supprimerLieu(object sender, RoutedEventArgs e)
        {
            if (listeLieux.SelectedItem is LieuViewModel)
            {
                LieuViewModel toRemove = (LieuViewModel)listeLieux.SelectedItem;
                lp.Remove(toRemove);
                listeLieux.Items.Refresh();
                LieuORM.supprimerLieu(selectedLieuId);
            }
        }
    }
}