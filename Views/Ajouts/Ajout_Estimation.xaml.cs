using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using BidCardCoin.Crtl;
using BidCardCoin.DAL;
using BidCardCoin.ORM;

namespace BidCardCoin.Views
{
    public partial class Ajout_Estimation : UserControl
    {
        public Ajout_Estimation()
        {
            InitializeComponent();

            DALConnection.OpenConnection();
            
            loadEstimations();
            
            loadCommissaire_Priseurs();
            
            loadVendeur();
            
            appliquerContexte();

            gererEventSupplémentaires();
        }
        
        EstimationViewModel myDataObject; // Objet de liaison avec la vue lors de l'ajout d'une Estimation par exemple.
        ObservableCollection<EstimationViewModel> es;
        
        Commissaire_PriseurViewModel myDataObjectCommissaire_Priseur; // Objet de liaison avec la vue lors de l'ajout d'une Estimation par exemple.
        ObservableCollection<Commissaire_PriseurViewModel> co;
        
        VendeurViewModel myDataObjectVendeur; // Objet de liaison avec la vue lors de l'ajout d'une Estimation par exemple.
        ObservableCollection<VendeurViewModel> ve;
        int compteur = 0;
        
        void loadEstimations()
        {
            es = EstimationORM.listeEstimations();
            myDataObject = new EstimationViewModel();
            //LIEN AVEC la VIEW
            /*listeEstimations.ItemsSource = lp; // bind de la liste avec la source, permettant le binding.*/
        }

        private void btnReturn(object sender, RoutedEventArgs e)
        {
            Commissaire_Priseur ucObj = new Commissaire_Priseur();
            stkTest.Children.Clear();
            stkTest.Children.Add(ucObj);
        }
        void loadCommissaire_Priseurs()
        {
            co = Commissaire_PriseurORM.listeCommissaire_Priseurs();
            myDataObjectCommissaire_Priseur = new Commissaire_PriseurViewModel();
            ComboBoxCommissaire_Priseur.ItemsSource = co;
            //LIEN AVEC la VIEW
            /*listeAchats.ItemsSource = lp; // bind de la liste avec la source, permettant le binding.*/
        }
        
        void loadVendeur()
        {
            ve = VendeurORM.listeVendeurs();
            myDataObjectVendeur = new VendeurViewModel();
            ComboBoxVendeur.ItemsSource = ve;
            //LIEN AVEC la VIEW
            /*listeAchats.ItemsSource = lp; // bind de la liste avec la source, permettant le binding.*/
        }
        void appliquerContexte()
        {
            // Lien avec les textbox
            ComboBoxCommissaire_Priseur.DataContext = myDataObject;
            ComboBoxVendeur.DataContext = myDataObject;
        }

        void gererEventSupplémentaires()
        {
        }
        
        private void btnAjouter(object sender, RoutedEventArgs e)
        {
            es.Add(myDataObject);
            EstimationORM.insertEstimation(myDataObject);
            compteur = es.Count();

            // Comme on a inséré une Estimation, on crée un nouvel objet EstimationViewModel
            // Et on réatache tout ce qu'il faut pour que la vue soit propre
            myDataObject = new EstimationViewModel();

            // Comme le contexte des élément de la vue est encore l'ancien EstimationViewModel,
            // On refait les liens entre age, slider, textbox, bouton et le nouveau EstimationViewModel
            ComboBoxCommissaire_Priseur.DataContext = myDataObject;
            ComboBoxVendeur.DataContext = myDataObject;
        }
    }
}