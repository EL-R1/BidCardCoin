using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using BidCardCoin.Crtl;
using BidCardCoin.DAL;
using BidCardCoin.ORM;

namespace BidCardCoin.Views
{
    public partial class Ajout_Achat : UserControl
    {
        public Ajout_Achat()
        {
            InitializeComponent();

            DALConnection.OpenConnection();
            
            loadAchats();

            loadProduits();

            loadAcheteurs();

            appliquerContexte();

            gererEventSupplémentaires();
        }
        
        AchatViewModel myDataObject; // Objet de liaison avec la vue lors de l'ajout d'une Achat par exemple.
        ObservableCollection<AchatViewModel> lp;
        int compteur = 0;
        
        AcheteurViewModel myDataObjectacheteur; // Objet de liaison avec la vue lors de l'ajout d'une Achat par exemple.
        ObservableCollection<AcheteurViewModel> ac;


        ProduitViewModel myDataObjectProduit; // Objet de liaison avec la vue lors de l'ajout d'une Achat par exemple.
        ObservableCollection<ProduitViewModel> pr;
        
        void loadAchats()
        {
            lp = AchatORM.listeAchats();
            myDataObject = new AchatViewModel();
            //LIEN AVEC la VIEW
            /*listeAchats.ItemsSource = lp; // bind de la liste avec la source, permettant le binding.*/
        }

        void loadProduits()
        {
            pr = ProduitORM.listeProduits();
            myDataObjectProduit = new ProduitViewModel();
            ComboBoxProduit.ItemsSource = pr;
            //LIEN AVEC la VIEW
            /*listeAchats.ItemsSource = lp; // bind de la liste avec la source, permettant le binding.*/
        }
        
        
        void loadAcheteurs()
        {
            ac = AcheteurORM.listeAcheteurs();
            myDataObjectacheteur = new AcheteurViewModel();
            ComboBoxAcheteur.ItemsSource = ac;
            //LIEN AVEC la VIEW
            /*listeAchats.ItemsSource = lp; // bind de la liste avec la source, permettant le binding.*/
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
            Achat ucObj = new Achat();
            stkTest.Children.Clear();
            stkTest.Children.Add(ucObj);
        }
        private void btnAjouter(object sender, RoutedEventArgs e)
        {

            lp.Add(myDataObject);
            AchatORM.insertAchat(myDataObject);
            compteur = lp.Count();

            // Comme on a inséré une Achat, on crée un nouvel objet AchatViewModel
            // Et on réatache tout ce qu'il faut pour que la vue soit propre
            myDataObject = new AchatViewModel();

            // Comme le contexte des élément de la vue est encore l'ancien AchatViewModel,
            // On refait les liens entre age, slider, textbox, bouton et le nouveau AchatViewModel
            ComboBoxProduit.DataContext = myDataObjectProduit;
            ComboBoxAcheteur.DataContext = myDataObjectacheteur;
        }
    }
}