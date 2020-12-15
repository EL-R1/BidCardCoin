using System.Collections.ObjectModel;
using BidCardCoin.DAL;

namespace BidCardCoin.DAO
{
    public class Ordre_AchatDAO
    {
        public int id_ordre_achat;
        public int id_produit;
        public int id_acheteur;
        public double montant;
        public string date_achat;

        public Ordre_AchatDAO(int id_ordre_achat_,int id_produit_,int id_acheteur_,double montant_,string date_achat_)
        {
            this.id_ordre_achat = id_ordre_achat_;
            this.id_produit = id_produit_;
            this.id_acheteur = id_acheteur_;
            this.montant = montant_;
            this.date_achat = date_achat_;
        }
        public static ObservableCollection<Ordre_AchatDAO>  listeOrdre_Achats()
        {
            ObservableCollection<Ordre_AchatDAO> l = Ordre_AchatDAL.selectOrdre_Achats();
            return l;
        }

        public static Ordre_AchatDAO getOrdre_Achat(int idOrdre_Achat)
        {
            Ordre_AchatDAO p = Ordre_AchatDAL.getOrdre_Achat(idOrdre_Achat);
            return p;
        }

        public static void updateOrdre_Achat(Ordre_AchatDAO p)
        {
            Ordre_AchatDAL.updateOrdre_Achat(p);
        }

        public static void supprimerOrdre_Achat(int id)
        {
            Ordre_AchatDAL.supprimerOrdre_Achat(id);
        }

        public static void insertOrdre_Achat(Ordre_AchatDAO p)
        {
            Ordre_AchatDAL.insertOrdre_Achat(p);
        }
    }
}