using System.Collections.ObjectModel;
using BidCardCoin.DAL;

namespace BidCardCoin.DAO
{
    public class CategorieProduitDAO
    {
        public int id_produit;
        public int id_categorie;

        public CategorieProduitDAO(int id_produit_,int id_categorie_)
        {
            this.id_produit = id_produit_;
            this.id_categorie = id_categorie_;
        }

        public string nom_cat;
        public CategorieProduitDAO(string nom_cat)
        {
            this.nom_cat = nom_cat;
        }
        
        
        public static ObservableCollection<CategorieProduitDAO>  listeCategorieProduits()
        {
            ObservableCollection<CategorieProduitDAO> l = CategorieProduitDAL.selectCategorieProduits();
            return l;
        }

        public static CategorieProduitDAO getCategorieProduit(int id_categorie, int id_produit)
        {
            CategorieProduitDAO p = CategorieProduitDAL.getCategorieProduit(id_categorie, id_produit);
            return p;
        }

        public static void updateCategorieProduit(CategorieProduitDAO p)
        {
            CategorieProduitDAL.updateCategorieProduit(p);
        }

        public static void supprimerCategorieProduit(int id_categorie, int id_produit)
        {
            CategorieProduitDAL.supprimerCategorieProduit(id_categorie, id_produit);
        }

        public static void insertCategorieProduit(CategorieProduitDAO p)
        {
            CategorieProduitDAL.insertCategorieProduit(p);
        }
        
        public static ObservableCollection<CategorieProduitDAO> getProduit_Categorie(int id_produit)
        {
            ObservableCollection<CategorieProduitDAO> l = CategorieProduitDAL.getProduit_Categorie(id_produit);
            return l;
        }
    }
}