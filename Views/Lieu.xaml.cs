using System.Collections.ObjectModel;
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
    }
}