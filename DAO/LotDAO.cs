using System.Collections.ObjectModel;
using BidCardCoin.DAL;

namespace BidCardCoin.DAO
{
    public class LotDAO
    {
        public int id_lot;
        public int id_vente_enchere;
        public string description;

        public LotDAO(int id_lot_,int id_vente_enchere_,string description_)
        {
            this.id_lot = id_lot_;
            this.id_vente_enchere = id_vente_enchere_;
            this.description = description_;
        }
        public static ObservableCollection<LotDAO>  listeLots()
        {
            ObservableCollection<LotDAO> l = LotDAL.selectLots();
            return l;
        }

        public static LotDAO getLot(int idLot)
        {
            LotDAO p = LotDAL.getLot(idLot);
            return p;
        }

        public static void updateLot(LotDAO p)
        {
            LotDAL.updateLot(p);
        }

        public static void supprimerLot(int id)
        {
            LotDAL.supprimerLot(id);
        }

        public static void insertLot(LotDAO p)
        {
            LotDAL.insertLot(p);
        }
    }
}