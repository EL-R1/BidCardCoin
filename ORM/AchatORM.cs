using System.Collections.ObjectModel;
using BidCardCoin.Crtl;
using BidCardCoin.DAO;

namespace BidCardCoin.ORM
{
    public class AchatORM
    {
        public static AchatViewModel getAchat(int idAchat, int id_produit)
        {
            AchatDAO pDAO=AchatDAO.getAchat(idAchat, id_produit);
            AchatViewModel p = new AchatViewModel(pDAO.id_acheteur, pDAO.id_produit, pDAO.prix, pDAO.is_live, pDAO.is_telephone);
            return p;
        }

        public static ObservableCollection<AchatViewModel> listeAchats()
        {
            ObservableCollection<AchatDAO> lDAO = AchatDAO.listeAchats();
            ObservableCollection<AchatViewModel> l = new ObservableCollection<AchatViewModel>();
            foreach (AchatDAO element in lDAO)
            {
                AchatViewModel p = new AchatViewModel(element.id_acheteur, element.id_produit, element.prix, element.is_live, element.is_telephone);
                l.Add(p);
            }
            return l;
        }


        public static void updateAchat(AchatViewModel p)
        {
            AchatDAO.updateAchat(new AchatDAO(p.id_acheteur, p.id_produit, p.prix, p.is_live, p.is_telephone));
        }

        public static void supprimerAchat(int id, int id_produit)
        {
            AchatDAO.supprimerAchat(id, id_produit);
        }

        public static void insertAchat(AchatViewModel p)
        {
            AchatDAO.insertAchat(new AchatDAO(p.id_acheteur, p.id_produit, p.prix, p.is_live, p.is_telephone));
        }
    }
}