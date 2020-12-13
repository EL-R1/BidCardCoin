using System.Collections.ObjectModel;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using BidCardCoin.Crtl;
using BidCardCoin.DAL;
using BidCardCoin.ORM;

namespace BidCardCoin.Views
{
    public partial class Ajout_Lieu : UserControl
    {
        public Ajout_Lieu()
        {
            InitializeComponent();

            DALConnection.OpenConnection();
            
            loadLieus();

            appliquerContexte();

            gererEventSupplémentaires();
        }
        
        LieuViewModel myDataObject; // Objet de liaison avec la vue lors de l'ajout d'une Lieu par exemple.
        ObservableCollection<LieuViewModel> lp;
        int compteur = 0;
        
        void loadLieus()
        {
            lp = LieuORM.listeLieux();
            myDataObject = new LieuViewModel();
            //LIEN AVEC la VIEW
            /*listeLieus.ItemsSource = lp; // bind de la liste avec la source, permettant le binding.*/
        
        }
        
        void appliquerContexte()
        {
            // Lien avec les textbox
            nom.DataContext = myDataObject;
            adresse.DataContext = myDataObject;
            ville.DataContext = myDataObject;
            code_postal.DataContext = myDataObject;
            
        }

        void gererEventSupplémentaires()
        {
        }
        
        private void btnReturn(object sender, RoutedEventArgs e)
        {
            Lieu ucObj = new Lieu();
            stkTest.Children.Clear();
            stkTest.Children.Add(ucObj);
        }
        private void btnAjouter(object sender, RoutedEventArgs e)
        {
            myDataObject.id_lieu = LieuDAL.getMaxIdLieu() + 1;

            lp.Add(myDataObject);
            LieuORM.insertLieu(myDataObject);
            compteur = lp.Count();

            // Comme on a inséré une Lieu, on crée un nouvel objet LieuViewModel
            // Et on réatache tout ce qu'il faut pour que la vue soit propre
            myDataObject = new LieuViewModel();

            // Comme le contexte des élément de la vue est encore l'ancien LieuViewModel,
            // On refait les liens entre age, slider, textbox, bouton et le nouveau LieuViewModel
            nom.DataContext = myDataObject;
            adresse.DataContext = myDataObject;
            ville.DataContext = myDataObject;
            code_postal.DataContext = myDataObject;
        }
        private void Code_Postal(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("^[0-9]{1,5}$");
            e.Handled = regex.IsMatch(e.Text);
        }
        
    }
}