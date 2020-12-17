using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
 using BidCardCoin.Crtl;
 using BidCardCoin.ORM;
using System.Windows.Input;

 namespace BidCardCoin.Views
{
    public partial class Ordre_Achat : UserControl
    {
        public Ordre_Achat()
        {
            InitializeComponent();
            
            loadOrdre_Achats();
        }
        
        Ordre_AchatViewModel myDataObject; // Objet de liaison avec la vue lors de l'ajout d'une Ordre_Achat par exemple.
        ObservableCollection<Ordre_AchatViewModel> lp;
        int selectedOrdre_AchatId;
        
        void loadOrdre_Achats()
        {
            lp = Ordre_AchatORM.listeOrdre_Achats();
            myDataObject = new Ordre_AchatViewModel();
            //LIEN AVEC la VIEW
            listeOrdre_Achats.ItemsSource = lp; // bind de la liste avec la source, permettant le binding.
        }
        private void btnAjouter(object sender, RoutedEventArgs e)
        {
            Ajout_Ordre_Achat ucObj = new Ajout_Ordre_Achat();
            stkTest.Children.Clear();
            stkTest.Children.Add(ucObj);
        }
        
        private void btnAjouter_Ordre_Achat(object sender, RoutedEventArgs e)
        {
            Ajout_Ordre_Achat ucObj = new Ajout_Ordre_Achat();
            stkTest.Children.Clear();
            stkTest.Children.Add(ucObj);
        }

        private void listeOrdre_Achats_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if ((listeOrdre_Achats.SelectedIndex < lp.Count) && (listeOrdre_Achats.SelectedIndex >= 0))
            {
                selectedOrdre_AchatId = lp.ElementAt(listeOrdre_Achats.SelectedIndex).id;
            }
        }

        private void supprimerOrdre_Achat(object sender, RoutedEventArgs e)
        {
            if (listeOrdre_Achats.SelectedItem is Ordre_AchatViewModel)
            {
                Ordre_AchatViewModel toRemove = (Ordre_AchatViewModel)listeOrdre_Achats.SelectedItem;
                lp.Remove(toRemove);
                listeOrdre_Achats.Items.Refresh();
                Ordre_AchatORM.supprimerOrdre_Achat(selectedOrdre_AchatId);
            }
        }
    }
}