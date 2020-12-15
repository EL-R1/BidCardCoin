using System.ComponentModel;
using System.Runtime.CompilerServices;
using BidCardCoin.Annotations;
using BidCardCoin.ORM;

namespace BidCardCoin.Crtl
{
    public class VendeurViewModel : INotifyPropertyChanged
    {
        public VendeurViewModel() {}
        
        private int _id_vendeur;
        public int id
        {
            get { return _id_vendeur; }
            set { _id_vendeur = value; }
        }

        private int _id_personne;
        public int id_personne
        {
            get { return _id_personne; }
            set { _id_personne = value; }
        }

        private int _id_produit;
        public int id_produit
        {
            get { return _id_produit; }
            set { _id_produit = value; }
        }


        public VendeurViewModel(int id_vendeur_,int id_personne_,int id_produit_)
        {
            this.id = id_vendeur_;
            this.id_personne = id_personne_;
            this.id_produit = id_produit_;
        }

        
        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string info)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(info));
                this.PropertyChanged(this, new PropertyChangedEventArgs(info));
                VendeurORM.updateVendeur(this);
            }
        }
    }
}