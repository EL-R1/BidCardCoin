using System.Collections.ObjectModel;
using BidCardCoin.Crtl;
using BidCardCoin.DAO;

namespace BidCardCoin.ORM
{
    public class LieuORM
    {
        public static LieuViewModel getLieu(int idLieu)
        {
            LieuDAO pDAO=LieuDAO.getLieu(idLieu);
            LieuViewModel p = new LieuViewModel(pDAO.id, pDAO.nom, pDAO.adresse, pDAO.ville,pDAO.code_postal);
            return p;
        }

        public static ObservableCollection<LieuViewModel> listeLieux()
        {
            ObservableCollection<LieuDAO> lDAO = LieuDAO.listeLieux();
            ObservableCollection<LieuViewModel> l = new ObservableCollection<LieuViewModel>();
            foreach (LieuDAO element in lDAO)
            {
                LieuViewModel p = new LieuViewModel(element.id, element.nom, element.adresse, element.ville,element.code_postal);
                l.Add(p);
            }
            return l;
        }


        public static void updateLieu(LieuViewModel p)
        {
            LieuDAO.updateLieu(new LieuDAO(p.id, p.nom, p.adresse, p.ville,p.code_postal));
        }

        public static void supprimerLieu(int id)
        {
            LieuDAO.supprimerLieu(id);
        }

        public static void insertLieu(LieuViewModel p)
        {
            LieuDAO.insertLieu(new LieuDAO(p.id, p.nom, p.adresse, p.ville,p.code_postal));
        }
    }
}