using System.Collections.ObjectModel;
using BidCardCoin.DAL;

namespace BidCardCoin.DAO
{
    public class EstimationDAO
    {
        public int id_comissaire_priseur;
        public int id_vendeur;

        public EstimationDAO(int id_comissaire_priseur_,int id_vendeur_)
        {
            this.id_comissaire_priseur = id_comissaire_priseur_;
            this.id_vendeur = id_vendeur_;
        }
        public static ObservableCollection<EstimationDAO>  listeEstimations()
        {
            ObservableCollection<EstimationDAO> l = EstimationDAL.selectEstimations();
            return l;
        }

        public static EstimationDAO getEstimation(int id_commissaire_priseur, int id_vendeur)
        {
            EstimationDAO p = EstimationDAL.getEstimation(id_commissaire_priseur, id_vendeur);
            return p;
        }

        public static void updateEstimation(EstimationDAO p)
        {
            EstimationDAL.updateEstimation(p);
        }

        public static void supprimerEstimation(int id_commissaire_priseur, int id_vendeur)
        {
            EstimationDAL.supprimerEstimation(id_commissaire_priseur, id_vendeur);
        }

        public static void insertEstimation(EstimationDAO p)
        {
            EstimationDAL.insertEstimation(p);
        }
    }
}