using System.Collections.ObjectModel;
using BidCardCoin.DAL;

namespace BidCardCoin.DAO
{
    public class VendeurDAO
    {
        public int id_vendeur;
        public int id_personne;
        public int id_produit;

        public VendeurDAO(int id_vendeur_,int id_personne_,int id_produit_)
        {
            this.id_vendeur = id_vendeur_;
            this.id_personne = id_personne_;
            this.id_produit = id_produit_;
        }
        public static ObservableCollection<VendeurDAO>  listeVendeurs()
        {
            ObservableCollection<VendeurDAO> l = VendeurDAL.selectVendeurs();
            return l;
        }

        public static VendeurDAO getVendeur(int idVendeur)
        {
            VendeurDAO p = VendeurDAL.getVendeur(idVendeur);
            return p;
        }

        public static void updateVendeur(VendeurDAO p)
        {
            VendeurDAL.updateVendeur(p);
        }

        public static void supprimerVendeur(int id)
        {
            VendeurDAL.supprimerVendeur(id);
        }

        public static void insertVendeur(VendeurDAO p)
        {
            VendeurDAL.insertVendeur(p);
        }
    }
}