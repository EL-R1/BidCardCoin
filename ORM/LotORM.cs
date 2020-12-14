using System.Collections.ObjectModel;
using BidCardCoin.Crtl;
using BidCardCoin.DAO;

namespace BidCardCoin.ORM
{
    public class LotORM
    {
        public static LotViewModel getLot(int idLot)
        {
            LotDAO pDAO=LotDAO.getLot(idLot);
            LotViewModel p = new LotViewModel(pDAO.id_lot, pDAO.id_vente_enchere, pDAO.description);
            return p;
        }

        public static ObservableCollection<LotViewModel> listeLots()
        {
            ObservableCollection<LotDAO> lDAO = LotDAO.listeLots();
            ObservableCollection<LotViewModel> l = new ObservableCollection<LotViewModel>();
            foreach (LotDAO element in lDAO)
            {
                LotViewModel p = new LotViewModel(element.id_lot, element.id_vente_enchere, element.description);
                l.Add(p);
            }
            return l;
        }


        public static void updateLot(LotViewModel p)
        {
            LotDAO.updateLot(new LotDAO(p.id, p.id_vente_enchere, p.description));
        }

        public static void supprimerLot(int id)
        {
            LotDAO.supprimerLot(id);
        }

        public static void insertLot(LotViewModel p)
        {
            LotDAO.insertLot(new LotDAO(p.id, p.id_vente_enchere, p.description));
        }
    }
}