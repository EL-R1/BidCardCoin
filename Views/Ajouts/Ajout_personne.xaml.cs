using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using BidCardCoin.Crtl;
using BidCardCoin.DAL;
using BidCardCoin.ORM;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Input;
using System.Security;

namespace BidCardCoin.Views
{
    public partial class Ajout_Personne : UserControl
    {
        public Ajout_Personne()
        {
            InitializeComponent();

            DALConnection.OpenConnection();
            
            loadPersonnes();

            appliquerContexte();

            gererEventSupplémentaires();
        }
        
        PersonneViewModel myDataObject; // Objet de liaison avec la vue lors de l'ajout d'une Personne par exemple.
        ObservableCollection<PersonneViewModel> lp;
        int compteur = 0;
        
        void loadPersonnes()
        {
            lp = PersonneORM.listePersonnes();
            myDataObject = new PersonneViewModel();
            //LIEN AVEC la VIEW
            /*listePersonnes.ItemsSource = lp; // bind de la liste avec la source, permettant le binding.*/
        
        }
        
        void appliquerContexte()
        {
            // Lien avec les textbox
            nom.DataContext = myDataObject;
            email.DataContext = myDataObject;
            age.DataContext = myDataObject;
            username.DataContext = myDataObject;
            password.DataContext = myDataObject;
        }

        void gererEventSupplémentaires()
        {
        }
        
        private void btnReturn(object sender, RoutedEventArgs e)
        {
            Personne ucObj = new Personne();
            stkTest.Children.Clear();
            stkTest.Children.Add(ucObj);
        }

        private void btnAjouter(object sender, RoutedEventArgs e)
        {
            myDataObject.id = PersonneDAL.getMaxIdPersonne() + 1;

            lp.Add(myDataObject);
            PersonneORM.insertPersonne(myDataObject);
            compteur = lp.Count();

            // Comme on a inséré une Personne, on crée un nouvel objet PersonneViewModel
            // Et on réatache tout ce qu'il faut pour que la vue soit propre
            myDataObject = new PersonneViewModel();

            // Comme le contexte des élément de la vue est encore l'ancien PersonneViewModel,
            // On refait les liens entre age, slider, textbox, bouton et le nouveau PersonneViewModel
            nom.DataContext = myDataObject;
            email.DataContext = myDataObject;
            age.DataContext = myDataObject;
            password.DataContext = myDataObject;
            username.DataContext = myDataObject;
        }
        
        private void NumericOnly(System.Object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            e.Handled = IsTextNumeric(e.Text);

        }
        private static bool IsTextNumeric(string str)
        {
            System.Text.RegularExpressions.Regex reg = new System.Text.RegularExpressions.Regex("[^0-9]");
            return reg.IsMatch(str);

        }
        
        private void IntOnly(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}