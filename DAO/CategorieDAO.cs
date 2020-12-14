using System.Collections.ObjectModel;
using BidCardCoin.DAL;

namespace BidCardCoin.DAO
{
    public class CategorieDAO
    {
        public int id_categorie;
        public string nom;

        public CategorieDAO(int id_categorie_,string nom_)
        {
            this.id_categorie = id_categorie_;
            this.nom = nom_;
        }
        public static ObservableCollection<CategorieDAO>  listeCategories()
        {
            ObservableCollection<CategorieDAO> l = CategorieDAL.selectCategories();
            return l;
        }

        public static CategorieDAO getCategorie(int idCategorie)
        {
            CategorieDAO p = CategorieDAL.getCategorie(idCategorie);
            return p;
        }

        public static void updateCategorie(CategorieDAO p)
        {
            CategorieDAL.updateCategorie(p);
        }

        public static void supprimerCategorie(int id)
        {
            CategorieDAL.supprimerCategorie(id);
        }

        public static void insertCategorie(CategorieDAO p)
        {
            CategorieDAL.insertCategorie(p);
        }
    }
}