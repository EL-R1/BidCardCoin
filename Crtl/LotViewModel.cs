using System.ComponentModel;
using System.Runtime.CompilerServices;
using BidCardCoin.Annotations;
using BidCardCoin.ORM;

namespace BidCardCoin.Crtl
{
    public class LotViewModel : INotifyPropertyChanged
    {
        public LotViewModel() {}
        
        private int _id_lot;
        public int id_lot
        {
            get { return _id_lot; }
            set { _id_lot = value; }
        }

        private int _id_vente_enchere;
        public int id_vente_enchere
        {
            get { return _id_vente_enchere; }
            set { _id_vente_enchere = value; OnPropertyChanged("id_vente_enchere"); }
        }

        private string _description;
        public string description
        {
            get { return _description; }
            set { _description = value; OnPropertyChanged("description"); }
        }


        public LotViewModel(int id_lot_,int id_vente_enchere_,string description_)
        {
            this.id_lot = id_lot_;
            this.id_vente_enchere = id_vente_enchere_;
            this.description = description_;
        }

        
        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string info)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(info));
                this.PropertyChanged(this, new PropertyChangedEventArgs(info));
                LotORM.updateLot(this);
            }
        }
    }
}