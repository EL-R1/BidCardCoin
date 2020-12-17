using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
 using BidCardCoin.Crtl;
 using BidCardCoin.ORM;
using System.Windows.Input;

 namespace BidCardCoin.Views
{
    public partial class Acheteur : UserControl
    {
        public Acheteur()
        {
            InitializeComponent();
            
            loadAcheteurs();
        }
        
        AcheteurViewModel myDataObject; // Objet de liaison avec la vue lors de l'ajout d'une Acheteur par exemple.
        ObservableCollection<AcheteurViewModel> lp;
        int selectedAcheteursId;
        
        void loadAcheteurs()
        {
            lp = AcheteurORM.listeAcheteurs();
            myDataObject = new AcheteurViewModel();
            //LIEN AVEC la VIEW
            listeAcheteurs.ItemsSource = lp; // bind de la liste avec la source, permettant le binding.
        }
        private void btnAjouter(object sender, RoutedEventArgs e)
        {
            Ajout_Acheteur ucObj = new Ajout_Acheteur();
            stkTest.Children.Clear();
            stkTest.Children.Add(ucObj);
        }
        
        private void btnAjouter_Achat(object sender, RoutedEventArgs e)
        {
            Achat ucObj = new Achat();
            stkTest.Children.Clear();
            stkTest.Children.Add(ucObj);
        }

        private void listeAcheteurs_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if ((listeAcheteurs.SelectedIndex < lp.Count) && (listeAcheteurs.SelectedIndex >= 0))
            {
                selectedAcheteursId = lp.ElementAt(listeAcheteurs.SelectedIndex).id;
            }
        }

        private void supprimerAcheteur(object sender, RoutedEventArgs e)
        {
            if (listeAcheteurs.SelectedItem is AcheteurViewModel)
            {
                AcheteurViewModel toRemove = (AcheteurViewModel)listeAcheteurs.SelectedItem;
                lp.Remove(toRemove);
                listeAcheteurs.Items.Refresh();
                AcheteurORM.supprimerAcheteur(selectedAcheteursId);
            }
        }
    }
}