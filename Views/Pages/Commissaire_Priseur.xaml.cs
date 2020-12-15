using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
 using BidCardCoin.Crtl;
 using BidCardCoin.ORM;
using System.Windows.Input;

 namespace BidCardCoin.Views
{
    public partial class Commissaire_Priseur : UserControl
    {
        public Commissaire_Priseur()
        {
            InitializeComponent();
            
            loadCommissaire_Priseurs();
        }
        
        Commissaire_PriseurViewModel myDataObject; // Objet de liaison avec la vue lors de l'ajout d'une Commissaire_Priseur par exemple.
        ObservableCollection<Commissaire_PriseurViewModel> lp;
        int compteur = 0;
        int selectedCommissaire_PriseursId;
        
        void loadCommissaire_Priseurs()
        {
            lp = Commissaire_PriseurORM.listeCommissaire_Priseurs();
            myDataObject = new Commissaire_PriseurViewModel();
            //LIEN AVEC la VIEW
            listeCommissaire_Priseurs.ItemsSource = lp; // bind de la liste avec la source, permettant le binding.
        }
        private void btnAjouter(object sender, RoutedEventArgs e)
        {
            Ajout_Commissaire_Priseur ucObj = new Ajout_Commissaire_Priseur();
            stkTest.Children.Clear();
            stkTest.Children.Add(ucObj);
        }

        private void listeCommissaire_Priseurs_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if ((listeCommissaire_Priseurs.SelectedIndex < lp.Count) && (listeCommissaire_Priseurs.SelectedIndex >= 0))
            {
                selectedCommissaire_PriseursId = lp.ElementAt(listeCommissaire_Priseurs.SelectedIndex).id;
            }
        }

        private void supprimerCommissaire_Priseur(object sender, RoutedEventArgs e)
        {
            if (listeCommissaire_Priseurs.SelectedItem is Commissaire_PriseurViewModel)
            {
                Commissaire_PriseurViewModel toRemove = (Commissaire_PriseurViewModel)listeCommissaire_Priseurs.SelectedItem;
                lp.Remove(toRemove);
                listeCommissaire_Priseurs.Items.Refresh();
                Commissaire_PriseurORM.supprimerCommissaire_Priseur(selectedCommissaire_PriseursId);
            }
        }
    }
}