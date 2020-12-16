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
    public partial class Ajout_Acheteur : UserControl
    {
        public Ajout_Acheteur()
        {
            InitializeComponent();

            DALConnection.OpenConnection();
            
            loadAcheteurs();

            loadPersonnes();

            appliquerContexte();

            gererEventSupplémentaires();
        }
        
        AcheteurViewModel myDataObject; // Objet de liaison avec la vue lors de l'ajout d'une Acheteur par exemple.
        ObservableCollection<AcheteurViewModel> lp;
        int compteur = 0;
        
        PersonneViewModel myDataObjectPersonne; // Objet de liaison avec la vue lors de l'ajout d'une Acheteur par exemple.
        ObservableCollection<PersonneViewModel> pe;
        
        void loadAcheteurs()
        {
            lp = AcheteurORM.listeAcheteurs();
            myDataObject = new AcheteurViewModel();
            //LIEN AVEC la VIEW
            /*listeAcheteurs.ItemsSource = lp; // bind de la liste avec la source, permettant le binding.*/
        }
        
        void loadPersonnes()
        {
            pe = PersonneORM.listePersonnes();
            myDataObjectPersonne = new PersonneViewModel();
            ComboBoxPersonne.ItemsSource = pe;
            //LIEN AVEC la VIEW
            /*listeAcheteurs.ItemsSource = lp; // bind de la liste avec la source, permettant le binding.*/
        }
        
        void appliquerContexte()
        {
            // Lien avec les textbox
            is_solvable.DataContext = myDataObject;
            ComboBoxPersonne.DataContext = myDataObject;
        }

        void gererEventSupplémentaires()
        {
        }
        
        private void btnReturn(object sender, RoutedEventArgs e)
        {
            Acheteur ucObj = new Acheteur();
            stkTest.Children.Clear();
            stkTest.Children.Add(ucObj);
        }
        private void btnAjouter(object sender, RoutedEventArgs e)
        {
            myDataObject.id = AcheteurDAL.getMaxIdAcheteur() + 1;

            lp.Add(myDataObject);
            AcheteurORM.insertAcheteur(myDataObject);
            compteur = lp.Count();

            // Comme on a inséré une Acheteur, on crée un nouvel objet AcheteurViewModel
            // Et on réatache tout ce qu'il faut pour que la vue soit propre
            myDataObject = new AcheteurViewModel();

            // Comme le contexte des élément de la vue est encore l'ancien AcheteurViewModel,
            // On refait les liens entre age, slider, textbox, bouton et le nouveau AcheteurViewModel
            is_solvable.DataContext = myDataObject;
            ComboBoxPersonne.DataContext = myDataObject;
        }
        
        private void BoolOnly(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-1]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}