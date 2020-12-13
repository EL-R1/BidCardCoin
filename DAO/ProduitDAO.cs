using System.Collections.ObjectModel;
using BidCardCoin.DAL;

namespace BidCardCoin.DAO
{
    public class ProduitDAO
    {
        public int id_produit;
        public int id_lot;
        public float prix_depart;
        public string description;
        public string date_vente;
        public float estimation;
        public byte is_vendu;
        public float prix_reserve;
        public string region;
        public string attribut;

        public ProduitDAO(int id_produit_,int id_lot_,float prix_depart_,string description_,string date_vente_,float estimation_,byte is_vendu_,float prix_reserve_,string region_,string attribut_)
        {
            this.id_produit = id_produit_;
            this.id_lot = id_lot_;
            this.prix_depart = prix_depart_;
            this.description = description_;
            this.date_vente = date_vente_;
            this.estimation = estimation_;
            this.is_vendu = is_vendu_;
            this.prix_reserve = prix_reserve_;
            this.region = region_;
            this.attribut = attribut_;
        }
        
        public static ObservableCollection<ProduitDAO>  listeProduits()
        {
            ObservableCollection<ProduitDAO> l = ProduitDAL.selectProduits();
            return l;
        }

        public static ProduitDAO getProduit(int idProduit)
        {
            ProduitDAO p = ProduitDAL.getProduit(idProduit);
            return p;
        }

        public static void updateProduit(ProduitDAO p)
        {
            ProduitDAL.updateProduit(p);
        }

        public static void supprimerProduit(int id)
        {
            ProduitDAL.supprimerProduit(id);
        }

        public static void insertProduit(ProduitDAO p)
        {
            ProduitDAL.insertProduit(p);
        }
    }
}