using System.ComponentModel;
using System.Runtime.CompilerServices;
using BidCardCoin.Annotations;
using BidCardCoin.ORM;

namespace BidCardCoin.Crtl
{
    public class EstimationViewModel : INotifyPropertyChanged
    {
        public EstimationViewModel() {}
        
        private int _id_comissaire_priseur;
        public int id_comissaire_priseur
        {
            get { return _id_comissaire_priseur; }
            set { _id_comissaire_priseur = value; OnPropertyChanged("id_commissaire_priseur");}
        }

        private int _id_vendeur;
        public int id_vendeur
        {
            get { return _id_vendeur; }
            set { _id_vendeur = value; OnPropertyChanged("id_vendeur"); }
        }


        public EstimationViewModel(int id_comissaire_priseur_,int id_vendeur_)
        {
            this.id_comissaire_priseur = id_comissaire_priseur_;
            this.id_vendeur = id_vendeur_;
        }

        public event PropertyChangedEventHandler PropertyChanged;



        private void OnPropertyChanged(string info)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(info));
                this.PropertyChanged(this, new PropertyChangedEventArgs(info));
                EstimationORM.updateEstimation(this);
            }
        }
    }
}