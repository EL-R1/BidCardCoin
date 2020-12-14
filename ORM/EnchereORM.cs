using System.Collections.ObjectModel;
using BidCardCoin.Crtl;
using BidCardCoin.DAO;

namespace BidCardCoin.ORM
{
    public class EnchereORM
    {
        public static EnchereViewModel getEnchere(int idEnchere)
        {
            EnchereDAO pDAO=EnchereDAO.getEnchere(idEnchere);
            EnchereViewModel p = new EnchereViewModel(pDAO.id_vente_enchere, pDAO.date_vente_enchere, pDAO.id_lieu);
            return p;
        }

        public static ObservableCollection<EnchereViewModel> listeEncheres()
        {
            ObservableCollection<EnchereDAO> lDAO = EnchereDAO.listeEncheres();
            ObservableCollection<EnchereViewModel> l = new ObservableCollection<EnchereViewModel>();
            foreach (EnchereDAO element in lDAO)
            {
                EnchereViewModel p = new EnchereViewModel(element.id_vente_enchere, element.date_vente_enchere, element.id_lieu);
                l.Add(p);
            }
            return l;
        }


        public static void updateEnchere(EnchereViewModel p)
        {
            EnchereDAO.updateEnchere(new EnchereDAO(p.id_vente_enchere, p.date_vente_enchere, p.id_lieu));
        }

        public static void supprimerEnchere(int id)
        {
            EnchereDAO.supprimerEnchere(id);
        }

        public static void insertEnchere(EnchereViewModel p)
        {
            EnchereDAO.insertEnchere(new EnchereDAO(p.id_vente_enchere, p.date_vente_enchere, p.id_lieu));
        }
    }
}