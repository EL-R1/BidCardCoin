using System.Collections.ObjectModel;
using BidCardCoin.DAL;

namespace BidCardCoin.DAO
{
    public class Commissaire_PriseurDAO
    {
        public int id_comissaire_priseur;
        public int id_produit;
        public int id_personne;

        public Commissaire_PriseurDAO(int id_comissaire_priseur_,int id_produit_,int id_personne_)
        {
            this.id_comissaire_priseur = id_comissaire_priseur_;
            this.id_produit = id_produit_;
            this.id_personne = id_personne_;
        }
        public static ObservableCollection<Commissaire_PriseurDAO>  listeCommissaire_Priseurs()
        {
            ObservableCollection<Commissaire_PriseurDAO> l = Commissaire_PriseurDAL.selectCommissaire_Priseurs();
            return l;
        }

        public static Commissaire_PriseurDAO getCommissaire_Priseur(int idCommissaire_Priseur)
        {
            Commissaire_PriseurDAO p = Commissaire_PriseurDAL.getCommissaire_Priseur(idCommissaire_Priseur);
            return p;
        }

        public static void updateCommissaire_Priseur(Commissaire_PriseurDAO p)
        {
            Commissaire_PriseurDAL.updateCommissaire_Priseur(p);
        }

        public static void supprimerCommissaire_Priseur(int id)
        {
            Commissaire_PriseurDAL.supprimerCommissaire_Priseur(id);
        }

        public static void insertCommissaire_Priseur(Commissaire_PriseurDAO p)
        {
            Commissaire_PriseurDAL.insertCommissaire_Priseur(p);
        }
    }
}