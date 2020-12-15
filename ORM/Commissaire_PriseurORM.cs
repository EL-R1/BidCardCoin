using System.Collections.ObjectModel;
using BidCardCoin.Crtl;
using BidCardCoin.DAO;

namespace BidCardCoin.ORM
{
    public class Commissaire_PriseurORM
    {
        public static Commissaire_PriseurViewModel getCommissaire_Priseur(int idCommissaire_Priseur)
        {
            Commissaire_PriseurDAO pDAO=Commissaire_PriseurDAO.getCommissaire_Priseur(idCommissaire_Priseur);
            Commissaire_PriseurViewModel p = new Commissaire_PriseurViewModel(pDAO.id_comissaire_priseur, pDAO.id_produit, pDAO.id_personne);
            return p;
        }

        public static ObservableCollection<Commissaire_PriseurViewModel> listeCommissaire_Priseurs()
        {
            ObservableCollection<Commissaire_PriseurDAO> lDAO = Commissaire_PriseurDAO.listeCommissaire_Priseurs();
            ObservableCollection<Commissaire_PriseurViewModel> l = new ObservableCollection<Commissaire_PriseurViewModel>();
            foreach (Commissaire_PriseurDAO element in lDAO)
            {
                Commissaire_PriseurViewModel p = new Commissaire_PriseurViewModel(element.id_comissaire_priseur, element.id_produit, element.id_personne);
                l.Add(p);
            }
            return l;
        }


        public static void updateCommissaire_Priseur(Commissaire_PriseurViewModel p)
        {
            Commissaire_PriseurDAO.updateCommissaire_Priseur(new Commissaire_PriseurDAO(p.id, p.id_produit, p.id_personne));
        }

        public static void supprimerCommissaire_Priseur(int id)
        {
            Commissaire_PriseurDAO.supprimerCommissaire_Priseur(id);
        }

        public static void insertCommissaire_Priseur(Commissaire_PriseurViewModel p)
        {
            Commissaire_PriseurDAO.insertCommissaire_Priseur(new Commissaire_PriseurDAO(p.id, p.id_produit, p.id_personne));
        }
    }
}