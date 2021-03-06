﻿using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using BidCardCoin.Crtl;
using BidCardCoin.DAL;
using BidCardCoin.ORM;
using System.Linq;

namespace BidCardCoin.Views
{
    public partial class Ajout_lot : UserControl
    {
        public Ajout_lot()
        {
            InitializeComponent();

            DALConnection.OpenConnection();
            
            loadLots();

            loadEncheres();

            appliquerContexte();

            gererEventSupplémentaires();
        }
        
        

        
        LotViewModel myDataObject; // Objet de liaison avec la vue lors de l'ajout d'une Lot par exemple.
        ObservableCollection<LotViewModel> lp;
        int compteur = 0;
        
        void loadLots()
        {
            lp = LotORM.listeLots();
            myDataObject = new LotViewModel();
            //LIEN AVEC la VIEW
            /*listeLots.ItemsSource = lp; // bind de la liste avec la source, permettant le binding.*/
        
        }
        
        EnchereViewModel myDataObjectEnchere; // Objet de liaison avec la vue lors de l'ajout d'une Lot par exemple.
        ObservableCollection<EnchereViewModel> en;
        void loadEncheres()
        {
            en = EnchereORM.listeEncheres();
            myDataObjectEnchere = new EnchereViewModel();
            ComboBoxEnchere.ItemsSource = en;
            //LIEN AVEC la VIEW
            /*listeEncheres.ItemsSource = lp; // bind de la liste avec la source, permettant le binding.*/
        
        }
        void appliquerContexte()
        {
            // Lien avec les textbox
            ComboBoxEnchere.DataContext = myDataObject;
            description.DataContext = myDataObject;
        }

        void gererEventSupplémentaires()
        {
        }
        
        private void btnReturn(object sender, RoutedEventArgs e)
        {
            Lot ucObj = new Lot();
            stkTest.Children.Clear();
            stkTest.Children.Add(ucObj);
        }
        private void btnAjouter(object sender, RoutedEventArgs e)
        {
            myDataObject.id = LotDAL.getMaxIdLot() + 1;

            lp.Add(myDataObject);
            LotORM.insertLot(myDataObject);
            compteur = lp.Count();

            // Comme on a inséré une Lot, on crée un nouvel objet LotViewModel
            // Et on réatache tout ce qu'il faut pour que la vue soit propre
            myDataObject = new LotViewModel();

            // Comme le contexte des élément de la vue est encore l'ancien LotViewModel,
            // On refait les liens entre age, slider, textbox, bouton et le nouveau LotViewModel
            ComboBoxEnchere.DataContext = myDataObject;
            description.DataContext = myDataObject;
        }
    }
}