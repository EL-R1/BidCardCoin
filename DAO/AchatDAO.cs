using System.Collections.ObjectModel;
using BidCardCoin.DAL;

namespace BidCardCoin.DAO
{
    public class AchatDAO
    {
        public int id_acheteur;
        public int id_produit;
        public double prix;
        public byte is_live;
        public byte is_telephone;

        public AchatDAO(int id_acheteur_,int id_produit_,double prix_,byte is_live_,byte is_telephone_)
        {
            this.id_acheteur = id_acheteur_;
            this.id_produit = id_produit_;
            this.prix = prix_;
            this.is_live = is_live_;
            this.is_telephone = is_telephone_;
        }
        public static ObservableCollection<AchatDAO>  listeAchats()
        {
            ObservableCollection<AchatDAO> l = AchatDAL.selectAchats();
            return l;
        }

        public static AchatDAO getAchat(int idAchat, int id_produit)
        {
            AchatDAO p = AchatDAL.getAchat(idAchat, id_produit);
            return p;
        }

        public static void updateAchat(AchatDAO p)
        {
            AchatDAL.updateAchat(p);
        }

        public static void supprimerAchat(int id, int id_produit)
        {
            AchatDAL.supprimerAchat(id, id_produit);
        }

        public static void insertAchat(AchatDAO p)
        {
            AchatDAL.insertAchat(p);
        }
    }
}