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
    public partial class Ajout_Ordre_Achat : UserControl
    {
        public Ajout_Ordre_Achat()
        {
            InitializeComponent();

            DALConnection.OpenConnection();
            
            loadOrdre_Achats();

            loadAcheteurs();
            
            loadProduits();

            appliquerContexte();

            gererEventSupplémentaires();
        }
        
        Ordre_AchatViewModel myDataObject; // Objet de liaison avec la vue lors de l'ajout d'une Ordre_Achat par exemple.
        ObservableCollection<Ordre_AchatViewModel> lp;
        int compteur = 0;
        
        AcheteurViewModel myDataObjectAcheteur; // Objet de liaison avec la vue lors de l'ajout d'une Acheteur par exemple.
        ObservableCollection<AcheteurViewModel> ac;
        
        ProduitViewModel myDataObjectProduit; // Objet de liaison avec la vue lors de l'ajout d'une Ordre_Achat par exemple.
        ObservableCollection<ProduitViewModel> pr;
        
        void loadOrdre_Achats()
        {
            lp = Ordre_AchatORM.listeOrdre_Achats();
            myDataObject = new Ordre_AchatViewModel();
            //LIEN AVEC la VIEW
            /*listeOrdre_Achats.ItemsSource = lp; // bind de la liste avec la source, permettant le binding.*/
        }
        
        void loadAcheteurs()
        {
            ac = AcheteurORM.listeAcheteurs();
            myDataObjectAcheteur = new AcheteurViewModel();
            ComboBoxAcheteur.ItemsSource = ac;
            //LIEN AVEC la VIEW
            /*listeOrdre_Achats.ItemsSource = lp; // bind de la liste avec la source, permettant le binding.*/
        }
        
        void loadProduits()
        {
            pr = ProduitORM.listeProduits();
            myDataObjectProduit = new ProduitViewModel();
            ComboBoxProduit.ItemsSource = pr;
            //LIEN AVEC la VIEW
            /*listeOrdre_Achats.ItemsSource = lp; // bind de la liste avec la source, permettant le binding.*/
        }
        
        void appliquerContexte()
        {
            // Lien avec les textbox
            ComboBoxAcheteur.DataContext = myDataObject;
            ComboBoxProduit.DataContext = myDataObject;
            montant.DataContext = myDataObject;
            date_achat.DataContext = myDataObject;
        }

        void gererEventSupplémentaires()
        {
        }
        
        private void btnReturn(object sender, RoutedEventArgs e)
        {
            Ordre_Achat ucObj = new Ordre_Achat();
            stkTest.Children.Clear();
            stkTest.Children.Add(ucObj);
        }
        private void btnAjouter(object sender, RoutedEventArgs e)
        {
            myDataObject.id = Ordre_AchatDAL.getMaxIdOrdre_Achat() + 1;

            lp.Add(myDataObject);
            Ordre_AchatORM.insertOrdre_Achat(myDataObject);
            compteur = lp.Count();

            // Comme on a inséré une Ordre_Achat, on crée un nouvel objet Ordre_AchatViewModel
            // Et on réatache tout ce qu'il faut pour que la vue soit propre
            myDataObject = new Ordre_AchatViewModel();

            // Comme le contexte des élément de la vue est encore l'ancien Ordre_AchatViewModel,
            // On refait les liens entre age, slider, textbox, bouton et le nouveau Ordre_AchatViewModel
            ComboBoxAcheteur.DataContext = myDataObject;
            ComboBoxProduit.DataContext = myDataObject;
            montant.DataContext = myDataObject;
            date_achat.DataContext = myDataObject;

        }
        
        private void FloatOnly(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+.");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}