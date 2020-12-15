using System.Collections.ObjectModel;
using BidCardCoin.DAL;

namespace BidCardCoin.DAO
{
    public class AcheteurDAO
    {
        public int id_acheteur;
        public int id_personne;
        public byte is_solvable;

        public AcheteurDAO(int id_acheteur_,int id_personne_,byte is_solvable_)
        {
            this.id_acheteur = id_acheteur_;
            this.id_personne = id_personne_;
            this.is_solvable = is_solvable_;
        }
        public static ObservableCollection<AcheteurDAO>  listeAcheteurs()
        {
            ObservableCollection<AcheteurDAO> l = AcheteurDAL.selectAcheteurs();
            return l;
        }

        public static AcheteurDAO getAcheteur(int idAcheteur)
        {
            AcheteurDAO p = AcheteurDAL.getAcheteur(idAcheteur);
            return p;
        }

        public static void updateAcheteur(AcheteurDAO p)
        {
            AcheteurDAL.updateAcheteur(p);
        }

        public static void supprimerAcheteur(int id)
        {
            AcheteurDAL.supprimerAcheteur(id);
        }

        public static void insertAcheteur(AcheteurDAO p)
        {
            AcheteurDAL.insertAcheteur(p);
        }
    }
}