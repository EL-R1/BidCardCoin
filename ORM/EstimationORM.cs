using System;
using System.Collections.ObjectModel;
using BidCardCoin.Crtl;
using BidCardCoin.DAO;

namespace BidCardCoin.ORM
{
    public class EstimationORM
    {
        public static EstimationViewModel getEstimation(int id_commissaire_priseur, int id_vendeur)
        {
            EstimationDAO pDAO=EstimationDAO.getEstimation(id_commissaire_priseur, id_vendeur);
            EstimationViewModel p = new EstimationViewModel(pDAO.id_comissaire_priseur, pDAO.id_vendeur);
            return p;
        }

        public static ObservableCollection<EstimationViewModel> listeEstimations()
        {
            ObservableCollection<EstimationDAO> lDAO = EstimationDAO.listeEstimations();
            ObservableCollection<EstimationViewModel> l = new ObservableCollection<EstimationViewModel>();
            foreach (EstimationDAO element in lDAO)
            {
                EstimationViewModel p = new EstimationViewModel(element.id_comissaire_priseur, element.id_vendeur);
                l.Add(p);
            }
            return l;
        }


        public static void updateEstimation(EstimationViewModel p)
        {
            EstimationDAO.updateEstimation(new EstimationDAO(p.id_comissaire_priseur, p.id_vendeur));
        }

        public static void supprimerEstimation(int id_categorie, int id_produit)
        {
            EstimationDAO.supprimerEstimation(id_categorie, id_produit);
        }

        public static void insertEstimation(EstimationViewModel p)
        {
            EstimationDAO.insertEstimation(new EstimationDAO(p.id_comissaire_priseur, p.id_vendeur));
        }
    }
}