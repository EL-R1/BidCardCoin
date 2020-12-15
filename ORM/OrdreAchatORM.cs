using System.Collections.ObjectModel;
using BidCardCoin.Crtl;
using BidCardCoin.DAO;

namespace BidCardCoin.ORM
{
    public class Ordre_AchatORM
    {
        public static Ordre_AchatViewModel getOrdre_Achat(int idOrdre_Achat)
        {
            Ordre_AchatDAO pDAO=Ordre_AchatDAO.getOrdre_Achat(idOrdre_Achat);
            Ordre_AchatViewModel p = new Ordre_AchatViewModel(pDAO.id_ordre_achat, pDAO.id_produit, pDAO.id_acheteur, pDAO.montant, pDAO.date_achat);
            return p;
        }

        public static ObservableCollection<Ordre_AchatViewModel> listeOrdre_Achats()
        {
            ObservableCollection<Ordre_AchatDAO> lDAO = Ordre_AchatDAO.listeOrdre_Achats();
            ObservableCollection<Ordre_AchatViewModel> l = new ObservableCollection<Ordre_AchatViewModel>();
            foreach (Ordre_AchatDAO element in lDAO)
            {
                Ordre_AchatViewModel p = new Ordre_AchatViewModel(element.id_ordre_achat, element.id_produit, element.id_acheteur, element.montant, element.date_achat);
                l.Add(p);
            }
            return l;
        }


        public static void updateOrdre_Achat(Ordre_AchatViewModel p)
        {
            Ordre_AchatDAO.updateOrdre_Achat(new Ordre_AchatDAO(p.id, p.id_produit, p.id_acheteur, p.montant, p.date_achat));
        }

        public static void supprimerOrdre_Achat(int id)
        {
            Ordre_AchatDAO.supprimerOrdre_Achat(id);
        }

        public static void insertOrdre_Achat(Ordre_AchatViewModel p)
        {
            Ordre_AchatDAO.insertOrdre_Achat(new Ordre_AchatDAO(p.id, p.id_produit, p.id_acheteur, p.montant, p.date_achat));
        }
    }
}