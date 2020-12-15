using System.Collections.ObjectModel;
using BidCardCoin.Crtl;
using BidCardCoin.DAO;

namespace BidCardCoin.ORM
{
    public class ProduitORM
    {
        public static ProduitViewModel getProduit(int idProduit)
        {
            ProduitDAO pDAO=ProduitDAO.getProduit(idProduit);
            ProduitViewModel p = new ProduitViewModel(pDAO.id_produit, pDAO.id_lot, pDAO.prix_depart, pDAO.description, pDAO.date_vente, pDAO.estimation, pDAO.is_vendu, pDAO.prix_reserve, pDAO.region, pDAO.attribut);
            return p;
        }

        public static ObservableCollection<ProduitViewModel> listeProduits()
        {
            ObservableCollection<ProduitDAO> lDAO = ProduitDAO.listeProduits();
            ObservableCollection<ProduitViewModel> l = new ObservableCollection<ProduitViewModel>();
            foreach (ProduitDAO element in lDAO)
            {
                ProduitViewModel p = new ProduitViewModel(element.id_produit, element.id_lot, element.prix_depart, element.description, element.date_vente, element.estimation, element.is_vendu, element.prix_reserve, element.region, element.attribut);
                l.Add(p);
            }
            return l;
        }


        public static void updateProduit(ProduitViewModel p)
        {
            ProduitDAO.updateProduit(new ProduitDAO(p.id, p.id_lot, p.prix_depart, p.description, p.date_vente, p.estimation, p.is_vendu, p.prix_reserve, p.region, p.attribut));
        }

        public static void supprimerProduit(int id)
        {
            ProduitDAO.supprimerProduit(id);
        }

        public static void insertProduit(ProduitViewModel p)
        {
            ProduitDAO.insertProduit(new ProduitDAO(p.id, p.id_lot, p.prix_depart, p.description, p.date_vente, p.estimation, p.is_vendu, p.prix_reserve, p.region, p.attribut));
        }
    }
}