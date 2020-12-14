using System.Collections.ObjectModel;
using BidCardCoin.DAL;

namespace BidCardCoin.DAO
{
    public class LieuDAO
    {
        public int id;
        public string nom;
        public string adresse;
        public string ville;
        public int code_postal;

        public LieuDAO(int id_lieu_,string nom_,string adresse_,string ville_,int code_postal_)
        {
            this.id = id_lieu_;
            this.nom = nom_;
            this.adresse = adresse_;
            this.ville = ville_;
            this.code_postal = code_postal_;
        }
        public static ObservableCollection<LieuDAO>  listeLieux()
        {
            ObservableCollection<LieuDAO> l = LieuDAL.selectLieux();
            return l;
        }

        public static LieuDAO getLieu(int idLieu)
        {
            LieuDAO p = LieuDAL.getLieu(idLieu);
            return p;
        }

        public static void updateLieu(LieuDAO p)
        {
            LieuDAL.updateLieu(p);
        }

        public static void supprimerLieu(int id)
        {
            LieuDAL.supprimerLieu(id);
        }

        public static void insertLieu(LieuDAO p)
        {
            LieuDAL.insertLieu(p);
        }
    }
}