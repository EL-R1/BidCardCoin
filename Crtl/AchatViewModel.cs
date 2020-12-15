using System.ComponentModel;
using System.Runtime.CompilerServices;
using BidCardCoin.Annotations;
using BidCardCoin.ORM;

namespace BidCardCoin.Crtl
{
    public class AchatViewModel : INotifyPropertyChanged
    {
        public AchatViewModel() {}
        
        private int _id_acheteur;
        public int id_acheteur
        {
            get { return _id_acheteur; }
            set { _id_acheteur = value; }
        }

        private int _id_produit;
        public int id_produit
        {
            get { return _id_produit; }
            set { _id_produit = value; }
        }

        private double _prix;
        public double prix
        {
            get { return _prix; }
            set { _prix = value; }
        }

        private byte _is_live;
        public byte is_live
        {
            get { return _is_live; }
            set { _is_live = value; }
        }

        private byte _is_telephone;
        public byte is_telephone
        {
            get { return _is_telephone; }
            set { _is_telephone = value; }
        }


        public AchatViewModel(int id_acheteur_,int id_produit_,double prix_,byte is_live_,byte is_telephone_)
        {
            this.id_acheteur = id_acheteur_;
            this.id_produit = id_produit_;
            this.prix = prix_;
            this.is_live = is_live_;
            this.is_telephone = is_telephone_;
        }

        
        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string info)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(info));
                this.PropertyChanged(this, new PropertyChangedEventArgs(info));
                AchatORM.updateAchat(this);
            }
        }
    }
}