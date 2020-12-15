using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using BidCardCoin.Crtl;
using BidCardCoin.DAL;
using BidCardCoin.ORM;

namespace BidCardCoin.Views
{
    public partial class Ajout_Photo : UserControl
    {
        public Ajout_Photo()
        {
            InitializeComponent();

            DALConnection.OpenConnection();
            
            loadPhotos();

            loadProduits();

            appliquerContexte();

            gererEventSupplémentaires();
        }
        
        PhotoViewModel myDataObject; // Objet de liaison avec la vue lors de l'ajout d'une Photo par exemple.
        ObservableCollection<PhotoViewModel> lp;
        int compteur = 0;

        ProduitViewModel myDataObjectProduit; // Objet de liaison avec la vue lors de l'ajout d'une Photo par exemple.
        ObservableCollection<ProduitViewModel> pr;
        
        void loadPhotos()
        {
            lp = PhotoORM.listePhotos();
            myDataObject = new PhotoViewModel();
            //LIEN AVEC la VIEW
            /*listePhotos.ItemsSource = lp; // bind de la liste avec la source, permettant le binding.*/
        }

        void loadProduits()
        {
            pr = ProduitORM.listeProduits();
            myDataObjectProduit = new ProduitViewModel();
            ComboBoxProduit.ItemsSource = pr;
            //LIEN AVEC la VIEW
            /*listePhotos.ItemsSource = lp; // bind de la liste avec la source, permettant le binding.*/
        }
        
        void appliquerContexte()
        {
            // Lien avec les textbox
            ComboBoxProduit.DataContext = myDataObject;
        }

        void gererEventSupplémentaires()
        {
        }
        
        private void btnReturn(object sender, RoutedEventArgs e)
        {
            Photo ucObj = new Photo();
            stkTest.Children.Clear();
            stkTest.Children.Add(ucObj);
        }
        private void btnAjouter(object sender, RoutedEventArgs e)
        {
            myDataObject.id = PhotoDAL.getMaxIdPhoto() + 1;

            lp.Add(myDataObject);
            PhotoORM.insertPhoto(myDataObject);
            compteur = lp.Count();

            // Comme on a inséré une Photo, on crée un nouvel objet PhotoViewModel
            // Et on réatache tout ce qu'il faut pour que la vue soit propre
            myDataObject = new PhotoViewModel();

            // Comme le contexte des élément de la vue est encore l'ancien PhotoViewModel,
            // On refait les liens entre age, slider, textbox, bouton et le nouveau PhotoViewModel
            ComboBoxProduit.DataContext = myDataObject;
        }
    }
}