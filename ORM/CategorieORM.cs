using System.Collections.ObjectModel;
using BidCardCoin.Crtl;
using BidCardCoin.DAO;

namespace BidCardCoin.ORM
{
    public class CategorieORM
    {
        public static CategorieViewModel getCategorie(int idCategorie)
        {
            CategorieDAO pDAO=CategorieDAO.getCategorie(idCategorie);
            CategorieViewModel p = new CategorieViewModel(pDAO.id_categorie, pDAO.nom);
            return p;
        }

        public static ObservableCollection<CategorieViewModel> listeCategories()
        {
            ObservableCollection<CategorieDAO> lDAO = CategorieDAO.listeCategories();
            ObservableCollection<CategorieViewModel> l = new ObservableCollection<CategorieViewModel>();
            foreach (CategorieDAO element in lDAO)
            {
                CategorieViewModel p = new CategorieViewModel(element.id_categorie, element.nom);
                l.Add(p);
            }
            return l;
        }


        public static void updateCategorie(CategorieViewModel p)
        {
            CategorieDAO.updateCategorie(new CategorieDAO(p.id, p.nom));
        }

        public static void supprimerCategorie(int id)
        {
            CategorieDAO.supprimerCategorie(id);
        }

        public static void insertCategorie(CategorieViewModel p)
        {
            CategorieDAO.insertCategorie(new CategorieDAO(p.id, p.nom));
        }
    }
}