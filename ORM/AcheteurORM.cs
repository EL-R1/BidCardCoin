using System.Collections.ObjectModel;
using BidCardCoin.Crtl;
using BidCardCoin.DAO;

namespace BidCardCoin.ORM
{
    public class AcheteurORM
    {
        public static AcheteurViewModel getAcheteur(int idAcheteur)
        {
            AcheteurDAO pDAO=AcheteurDAO.getAcheteur(idAcheteur);
            AcheteurViewModel p = new AcheteurViewModel(pDAO.id_acheteur, pDAO.id_personne, pDAO.is_solvable);
            return p;
        }

        public static ObservableCollection<AcheteurViewModel> listeAcheteurs()
        {
            ObservableCollection<AcheteurDAO> lDAO = AcheteurDAO.listeAcheteurs();
            ObservableCollection<AcheteurViewModel> l = new ObservableCollection<AcheteurViewModel>();
            foreach (AcheteurDAO element in lDAO)
            {
                AcheteurViewModel p = new AcheteurViewModel(element.id_acheteur, element.id_personne, element.is_solvable);
                l.Add(p);
            }
            return l;
        }


        public static void updateAcheteur(AcheteurViewModel p)
        {
            AcheteurDAO.updateAcheteur(new AcheteurDAO(p.id, p.id_personne, p.is_solvable));
        }

        public static void supprimerAcheteur(int id)
        {
            AcheteurDAO.supprimerAcheteur(id);
        }

        public static void insertAcheteur(AcheteurViewModel p)
        {
            AcheteurDAO.insertAcheteur(new AcheteurDAO(p.id, p.id_personne, p.is_solvable));
        }
    }
}