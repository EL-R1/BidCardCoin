using System.ComponentModel;
using System.Runtime.CompilerServices;
using BidCardCoin.Annotations;
using BidCardCoin.ORM;

namespace BidCardCoin.Crtl
{
    public class Ordre_AchatViewModel : INotifyPropertyChanged
    {
        public Ordre_AchatViewModel() {}
        
        private int _id_ordre_achat;
        public int id
        {
            get { return _id_ordre_achat; }
            set { _id_ordre_achat = value; }
        }

        private int _id_produit;
        public int id_produit
        {
            get { return _id_produit; }
            set { _id_produit = value; }
        }

        private int _id_acheteur;
        public int id_acheteur
        {
            get { return _id_acheteur; }
            set { _id_acheteur = value; }
        }

        private double _montant;
        public double montant
        {
            get { return _montant; }
            set { _montant = value; }
        }

        private string _date_achat;
        public string date_achat
        {
            get { return _date_achat; }
            set { _date_achat = value; }
        }


        public Ordre_AchatViewModel(int id_ordre_achat_,int id_produit_,int id_acheteur_,double montant_,string date_achat_)
        {
            this.id = id_ordre_achat_;
            this.id_produit = id_produit_;
            this.id_acheteur = id_acheteur_;
            this.montant = montant_;
            this.date_achat = date_achat_;
        }

        
        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string info)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(info));
                this.PropertyChanged(this, new PropertyChangedEventArgs(info));
                Ordre_AchatORM.updateOrdre_Achat(this);
            }
        }
    }
}