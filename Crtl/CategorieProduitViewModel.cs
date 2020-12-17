using System.ComponentModel;
using System.Runtime.CompilerServices;
using BidCardCoin.Annotations;
using BidCardCoin.ORM;

namespace BidCardCoin.Crtl
{
    public class CategorieProduitViewModel : INotifyPropertyChanged
    {
        public CategorieProduitViewModel() {}
        
        private int _id_produit;
        public int id_produit
        {
            get { return _id_produit; }
            set { _id_produit = value; OnPropertyChanged("id_produit");}
        }
        
        private string _nom_cat;
        public string nom_cat
        {
            get { return _nom_cat; }
            set { _nom_cat = value; OnPropertyChanged("nom_cat");}
        }

        private int _id_categorie;
        public int id_categorie
        {
            get { return _id_categorie; }
            set { _id_categorie = value; OnPropertyChanged("id_categorie");}
        }


        public CategorieProduitViewModel(int id_produit_,int id_categorie_)
        {
            this.id_produit = id_produit_;
            this.id_categorie = id_categorie_;
        }
        
        public CategorieProduitViewModel(string nom_cat)
        {
            this.nom_cat = nom_cat;
        }
        
        public event PropertyChangedEventHandler PropertyChanged;



        private void OnPropertyChanged(string info)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(info));
                this.PropertyChanged(this, new PropertyChangedEventArgs(info));
                CategorieProduitORM.updateCategorieProduit(this);
            }
        }
    }
}