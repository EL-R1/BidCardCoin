using System.Collections.ObjectModel;
using BidCardCoin.Crtl;
using BidCardCoin.DAO;

namespace BidCardCoin.ORM
{
    public class VendeurORM
    {
        public static VendeurViewModel getVendeur(int idVendeur)
        {
            VendeurDAO pDAO=VendeurDAO.getVendeur(idVendeur);
            VendeurViewModel p = new VendeurViewModel(pDAO.id_vendeur, pDAO.id_personne, pDAO.id_produit);
            return p;
        }

        public static ObservableCollection<VendeurViewModel> listeVendeurs()
        {
            ObservableCollection<VendeurDAO> lDAO = VendeurDAO.listeVendeurs();
            ObservableCollection<VendeurViewModel> l = new ObservableCollection<VendeurViewModel>();
            foreach (VendeurDAO element in lDAO)
            {
                VendeurViewModel p = new VendeurViewModel(element.id_vendeur, element.id_personne, element.id_produit);
                l.Add(p);
            }
            return l;
        }


        public static void updateVendeur(VendeurViewModel p)
        {
            VendeurDAO.updateVendeur(new VendeurDAO(p.id, p.id_personne, p.id_produit));
        }

        public static void supprimerVendeur(int id)
        {
            VendeurDAO.supprimerVendeur(id);
        }

        public static void insertVendeur(VendeurViewModel p)
        {
            VendeurDAO.insertVendeur(new VendeurDAO(p.id, p.id_personne, p.id_produit));
        }
    }
}