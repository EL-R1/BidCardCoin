using System.ComponentModel;
using System.Runtime.CompilerServices;
using BidCardCoin.Annotations;
using BidCardCoin.ORM;

namespace BidCardCoin.Crtl
{
    public class Commissaire_PriseurViewModel : INotifyPropertyChanged
    {
        public Commissaire_PriseurViewModel() {}
        
        private int _id_comissaire_priseur;
        public int id
        {
            get { return _id_comissaire_priseur; }
            set { _id_comissaire_priseur = value; }
        }

        private int _id_produit;
        public int id_produit
        {
            get { return _id_produit; }
            set { _id_produit = value; }
        }

        private int _id_personne;
        public int id_personne
        {
            get { return _id_personne; }
            set { _id_personne = value; }
        }


        public Commissaire_PriseurViewModel(int id_comissaire_priseur_,int id_produit_,int id_personne_)
        {
            this.id = id_comissaire_priseur_;
            this.id_produit = id_produit_;
            this.id_personne = id_personne_;
        }

        
        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string info)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(info));
                this.PropertyChanged(this, new PropertyChangedEventArgs(info));
                Commissaire_PriseurORM.updateCommissaire_Priseur(this);
            }
        }
    }
}