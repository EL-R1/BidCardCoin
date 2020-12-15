using System;
using System.Collections.ObjectModel;
using BidCardCoin.Crtl;
using BidCardCoin.DAO;

namespace BidCardCoin.ORM
{
    public class CategorieProduitORM
    {
        public static CategorieProduitViewModel getCategorieProduit(int id_categorie, int id_produit)
        {
            CategorieProduitDAO pDAO=CategorieProduitDAO.getCategorieProduit(id_categorie, id_produit);
            CategorieProduitViewModel p = new CategorieProduitViewModel(pDAO.id_produit, pDAO.id_categorie);
            return p;
        }

        public static ObservableCollection<CategorieProduitViewModel> listeCategorieProduits()
        {
            ObservableCollection<CategorieProduitDAO> lDAO = CategorieProduitDAO.listeCategorieProduits();
            ObservableCollection<CategorieProduitViewModel> l = new ObservableCollection<CategorieProduitViewModel>();
            foreach (CategorieProduitDAO element in lDAO)
            {
                CategorieProduitViewModel p = new CategorieProduitViewModel(element.id_produit, element.id_categorie);
                l.Add(p);
            }
            return l;
        }


        public static void updateCategorieProduit(CategorieProduitViewModel p)
        {
            CategorieProduitDAO.updateCategorieProduit(new CategorieProduitDAO(p.id_produit, p.id_categorie));
        }

        public static void supprimerCategorieProduit(int id_categorie, int id_produit)
        {
            CategorieProduitDAO.supprimerCategorieProduit(id_categorie, id_produit);
        }

        public static void insertCategorieProduit(CategorieProduitViewModel p)
        {
            CategorieProduitDAO.insertCategorieProduit(new CategorieProduitDAO(p.id_produit, p.id_categorie));
        }
    }
}