﻿using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
 using BidCardCoin.Crtl;
 using BidCardCoin.ORM;
using System.Windows.Input;

 namespace BidCardCoin.Views
{
    public partial class Lot : UserControl
    {
        public Lot()
        {
            InitializeComponent();
            
            loadLots();
        }
        
        LotViewModel myDataObject; // Objet de liaison avec la vue lors de l'ajout d'une Lot par exemple.
        ObservableCollection<LotViewModel> lp;
        int compteur = 0;
        int selectedLotsId;
        
        void loadLots()
        {
            lp = LotORM.listeLots();
            myDataObject = new LotViewModel();
            //LIEN AVEC la VIEW
            listeLots.ItemsSource = lp; // bind de la liste avec la source, permettant le binding.
        }
        private void btnAjouter(object sender, RoutedEventArgs e)
        {
            Ajout_lot ucObj = new Ajout_lot();
            stkTest.Children.Clear();
            stkTest.Children.Add(ucObj);
        }

        private void listeLots_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if ((listeLots.SelectedIndex < lp.Count) && (listeLots.SelectedIndex >= 0))
            {
                selectedLotsId = lp.ElementAt(listeLots.SelectedIndex).id;
            }
        }

        private void supprimerLot(object sender, RoutedEventArgs e)
        {
            if (listeLots.SelectedItem is LotViewModel)
            {
                LotViewModel toRemove = (LotViewModel)listeLots.SelectedItem;
                lp.Remove(toRemove);
                listeLots.Items.Refresh();
                LotORM.supprimerLot(selectedLotsId);
            }
        }
    }
}