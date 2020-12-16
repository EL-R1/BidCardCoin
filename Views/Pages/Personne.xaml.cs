﻿using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
 using BidCardCoin.Crtl;
 using BidCardCoin.ORM;

 namespace BidCardCoin.Views
{
    public partial class Personne : UserControl
    {
        public Personne()
        {
            InitializeComponent();
            
            loadPersonnes();
        }
        
        PersonneViewModel myDataObject; // Objet de liaison avec la vue lors de l'ajout d'une Personne par exemple.
        ObservableCollection<PersonneViewModel> lp;
        int selectedPersonneId;
        
        void loadPersonnes()
        {
            lp = PersonneORM.listePersonnes();
            myDataObject = new PersonneViewModel();
            //LIEN AVEC la VIEW
            listePersonnes.ItemsSource = lp; // bind de la liste avec la source, permettant le binding.
        }
        private void btnAjouter(object sender, RoutedEventArgs e)
        {
            Ajout_Personne ucObj = new Ajout_Personne();
            stkTest.Children.Clear();
            stkTest.Children.Add(ucObj);
        }
        private void btnPhoto(object sender, RoutedEventArgs e)
        {
            Photo ucObj = new Photo();
            stkTest.Children.Clear();
            stkTest.Children.Add(ucObj);
        }
        
        private void listePersonnes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if ((listePersonnes.SelectedIndex < lp.Count) && (listePersonnes.SelectedIndex >= 0))
            {
                selectedPersonneId = lp.ElementAt(listePersonnes.SelectedIndex).id;
            }
        }

        private void supprimerPersonne(object sender, RoutedEventArgs e)
        {
            if (listePersonnes.SelectedItem is PersonneViewModel)
            {
                PersonneViewModel toRemove = (PersonneViewModel)listePersonnes.SelectedItem;
                lp.Remove(toRemove);
                listePersonnes.Items.Refresh();
                PersonneORM.supprimerPersonne(selectedPersonneId);
            }
        }
    }
}