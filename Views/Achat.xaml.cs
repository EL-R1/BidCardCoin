using System;
 using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
 using BidCardCoin.Crtl;
 using BidCardCoin.ORM;
using System.Windows.Input;

 namespace BidCardCoin.Views
{
    public partial class Achat : UserControl
    {
        public Achat()
        {
            InitializeComponent();
            
            loadAchats();
        }
        
        AchatViewModel myDataObject; // Objet de liaison avec la vue lors de l'ajout d'une Achat par exemple.
        ObservableCollection<AchatViewModel> lp;
        int compteur = 0;
        int selectedAchatsId;
        int selectedProduitsId;
        
        void loadAchats()
        {
            lp = AchatORM.listeAchats();
            myDataObject = new AchatViewModel();
            //LIEN AVEC la VIEW
            listeAchats.ItemsSource = lp; // bind de la liste avec la source, permettant le binding.
        }
        private void btnAjouter(object sender, RoutedEventArgs e)
        {
            Ajout_Achat ucObj = new Ajout_Achat();
            stkTest.Children.Clear();
            stkTest.Children.Add(ucObj);
        }

        private void listeAchats_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if ((listeAchats.SelectedIndex < lp.Count) && (listeAchats.SelectedIndex >= 0))
            {
                selectedAchatsId = lp.ElementAt(listeAchats.SelectedIndex).id_acheteur;
            }
            
            if ((listeAchats.SelectedIndex < lp.Count) && (listeAchats.SelectedIndex >= 0))
            {
                selectedProduitsId = lp.ElementAt(listeAchats.SelectedIndex).id_produit;
            }
            
        }

        private void supprimerAchat(object sender, RoutedEventArgs e)
        {
            if (listeAchats.SelectedItem is AchatViewModel)
            {
                AchatViewModel toRemove = (AchatViewModel)listeAchats.SelectedItem;
                lp.Remove(toRemove);
                listeAchats.Items.Refresh();
                AchatORM.supprimerAchat(selectedAchatsId, selectedProduitsId);
            }
        }
    }
}