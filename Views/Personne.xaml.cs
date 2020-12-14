﻿using System.Collections.ObjectModel;
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
        int compteur = 0;
        
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
    }
}