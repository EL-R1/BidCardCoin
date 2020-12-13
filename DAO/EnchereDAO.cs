using System.Collections.ObjectModel;
using BidCardCoin.DAL;

namespace BidCardCoin.DAO
{
    public class EnchereDAO
    {

        public int id_vente_enchere;
        public string date_vente_enchere;
        public int id_lieu;
        
        public EnchereDAO(int id_vente_enchere_,string date_vente_enchere_,int id_lieu_)
        {
            this.id_vente_enchere = id_vente_enchere_;
            this.date_vente_enchere = date_vente_enchere_;
            this.id_lieu = id_lieu_;
        }
        
        
        public static ObservableCollection<EnchereDAO>  listeEncheres()
        {
            ObservableCollection<EnchereDAO> l = EnchereDAL.selectEncheres();
            return l;
        }

        public static EnchereDAO getEnchere(int idEnchere)
        {
            EnchereDAO p = EnchereDAL.getEnchere(idEnchere);
            return p;
        }

        public static void updateEnchere(EnchereDAO p)
        {
            EnchereDAL.updateEnchere(p);
        }

        public static void supprimerEnchere(int id)
        {
            EnchereDAL.supprimerEnchere(id);
        }

        public static void insertEnchere(EnchereDAO p)
        {
            EnchereDAL.insertEnchere(p);
        }
    }
}