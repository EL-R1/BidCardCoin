using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using BidCardCoin.Crtl;
using BidCardCoin.DAL;
using BidCardCoin.ORM;

namespace BidCardCoin.Views
{
    public partial class Ajout_Commissaire_Priseur : UserControl
    {
        public Ajout_Commissaire_Priseur()
        {
            InitializeComponent();

            DALConnection.OpenConnection();
            
            loadCommissaire_Priseurs();

            loadPersonnes();
            
            loadProduits();

            appliquerContexte();

            gererEventSupplémentaires();
        }
        
        Commissaire_PriseurViewModel myDataObject; // Objet de liaison avec la vue lors de l'ajout d'une Commissaire_Priseur par exemple.
        ObservableCollection<Commissaire_PriseurViewModel> lp;
        int compteur = 0;
        
        PersonneViewModel myDataObjectPersonne; // Objet de liaison avec la vue lors de l'ajout d'une Acheteur par exemple.
        ObservableCollection<PersonneViewModel> pe;
        
        ProduitViewModel myDataObjectProduit; // Objet de liaison avec la vue lors de l'ajout d'une Commissaire_Priseur par exemple.
        ObservableCollection<ProduitViewModel> pr;
        
        void loadCommissaire_Priseurs()
        {
            lp = Commissaire_PriseurORM.listeCommissaire_Priseurs();
            myDataObject = new Commissaire_PriseurViewModel();
            //LIEN AVEC la VIEW
            /*listeCommissaire_Priseurs.ItemsSource = lp; // bind de la liste avec la source, permettant le binding.*/
        }
        
        void loadPersonnes()
        {
            pe = PersonneORM.listePersonnes();
            myDataObjectPersonne = new PersonneViewModel();
            ComboBoxPersonne.ItemsSource = pe;
            //LIEN AVEC la VIEW
            /*listeCommissaire_Priseurs.ItemsSource = lp; // bind de la liste avec la source, permettant le binding.*/
        }
        
        void loadProduits()
        {
            pr = ProduitORM.listeProduits();
            myDataObjectProduit = new ProduitViewModel();
            ComboBoxProduit.ItemsSource = pr;
            //LIEN AVEC la VIEW
            /*listeCommissaire_Priseurs.ItemsSource = lp; // bind de la liste avec la source, permettant le binding.*/
        }
        
        void appliquerContexte()
        {
            // Lien avec les textbox
            ComboBoxPersonne.DataContext = myDataObject;
            ComboBoxProduit.DataContext = myDataObject;
        }

        void gererEventSupplémentaires()
        {
        }
        
        private void btnReturn(object sender, RoutedEventArgs e)
        {
            Commissaire_Priseur ucObj = new Commissaire_Priseur();
            stkTest.Children.Clear();
            stkTest.Children.Add(ucObj);
        }
        private void btnAjouter(object sender, RoutedEventArgs e)
        {
            myDataObject.id = Commissaire_PriseurDAL.getMaxIdCommissaire_Priseur() + 1;

            lp.Add(myDataObject);
            Commissaire_PriseurORM.insertCommissaire_Priseur(myDataObject);
            compteur = lp.Count();

            // Comme on a inséré une Commissaire_Priseur, on crée un nouvel objet Commissaire_PriseurViewModel
            // Et on réatache tout ce qu'il faut pour que la vue soit propre
            myDataObject = new Commissaire_PriseurViewModel();

            // Comme le contexte des élément de la vue est encore l'ancien Commissaire_PriseurViewModel,
            // On refait les liens entre age, slider, textbox, bouton et le nouveau Commissaire_PriseurViewModel
            ComboBoxPersonne.DataContext = myDataObject;
            ComboBoxProduit.DataContext = myDataObject;
        }
    }
}