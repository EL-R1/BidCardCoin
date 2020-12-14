using System.Collections.ObjectModel;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using BidCardCoin.Crtl;
using BidCardCoin.DAL;
using BidCardCoin.ORM;
using BidCardCoin.Vue;

namespace BidCardCoin.Views
{
    public partial class Ajout_enchere : UserControl
    {
        public Ajout_enchere()
        {
            InitializeComponent();

            DALConnection.OpenConnection();
            
            loadEncheres();
            
            loadLieux();

            appliquerContexte();

            gererEventSupplémentaires();
        }
        
        EnchereViewModel myDataObject; // Objet de liaison avec la vue lors de l'ajout d'une Enchere par exemple.
        ObservableCollection<EnchereViewModel> lp;
        
        LieuViewModel myDataObjectLieu; // Objet de liaison avec la vue lors de l'ajout d'une Enchere par exemple.
        ObservableCollection<LieuViewModel> li;
        
        int compteur = 0;
        
        void loadEncheres()
        {
            lp = EnchereORM.listeEncheres();
            myDataObject = new EnchereViewModel();
            
            //LIEN AVEC la VIEW
            /*listeEncheres.ItemsSource = lp; // bind de la liste avec la source, permettant le binding.*/
        
        }
        
        void loadLieux()
        {
            li = LieuORM.listeLieux();
            myDataObjectLieu = new LieuViewModel();
            ComboBoxLieu.ItemsSource = li;
            //LIEN AVEC la VIEW
            /*listeLieus.ItemsSource = lp; // bind de la liste avec la source, permettant le binding.*/
        }
        
        void appliquerContexte()
        {
            // Lien avec les textbox
            ComboBoxLieu.DataContext = myDataObject;
            date_vente_enchere.DataContext = myDataObject;
        }

        void gererEventSupplémentaires()
        {
        }
        
        private void btnReturn(object sender, RoutedEventArgs e)
        {
            Enchere ucObj = new Enchere();
            stkTest.Children.Clear();
            stkTest.Children.Add(ucObj);
        }
        private void btnAjouter(object sender, RoutedEventArgs e)
        {
            myDataObject.id_vente_enchere = EnchereDAL.getMaxIdEnchere() + 1;

            lp.Add(myDataObject);
            EnchereORM.insertEnchere(myDataObject);
            compteur = lp.Count();

            // Comme on a inséré une Enchere, on crée un nouvel objet EnchereViewModel
            // Et on réatache tout ce qu'il faut pour que la vue soit propre
            myDataObject = new EnchereViewModel();

            // Comme le contexte des élément de la vue est encore l'ancien EnchereViewModel,
            // On refait les liens entre age, slider, textbox, bouton et le nouveau EnchereViewModel
            date_vente_enchere.DataContext = myDataObject;
            ComboBoxLieu.DataContext = myDataObject;
        }
        
        private void IntOnly(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}