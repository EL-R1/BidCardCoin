using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
 using BidCardCoin.Crtl;
 using BidCardCoin.ORM;
using System.Windows.Input;

 namespace BidCardCoin.Views
{
    public partial class Photo : UserControl
    {
        public Photo()
        {
            InitializeComponent();
            
            loadPhotos();
        }
        
        PhotoViewModel myDataObject; // Objet de liaison avec la vue lors de l'ajout d'une Photo par exemple.
        ObservableCollection<PhotoViewModel> lp;
        int compteur = 0;
        int selectedPhotosId;
        
        void loadPhotos()
        {
            lp = PhotoORM.listePhotos();
            myDataObject = new PhotoViewModel();
            //LIEN AVEC la VIEW
            listePhotos.ItemsSource = lp; // bind de la liste avec la source, permettant le binding.
        }
        private void btnAjouter(object sender, RoutedEventArgs e)
        {
            Ajout_Photo ucObj = new Ajout_Photo();
            stkTest.Children.Clear();
            stkTest.Children.Add(ucObj);
        }

        private void listePhotos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if ((listePhotos.SelectedIndex < lp.Count) && (listePhotos.SelectedIndex >= 0))
            {
                selectedPhotosId = lp.ElementAt(listePhotos.SelectedIndex).id;
            }
        }

        private void supprimerPhoto(object sender, RoutedEventArgs e)
        {
            if (listePhotos.SelectedItem is PhotoViewModel)
            {
                PhotoViewModel toRemove = (PhotoViewModel)listePhotos.SelectedItem;
                lp.Remove(toRemove);
                listePhotos.Items.Refresh();
                PhotoORM.supprimerPhoto(selectedPhotosId);
            }
        }
    }
}