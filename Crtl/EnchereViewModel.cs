using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using BidCardCoin.Annotations;
using BidCardCoin.ORM;


namespace BidCardCoin.Crtl
{
    public class EnchereViewModel : INotifyPropertyChanged
    {
        private int _id_vente_enchere;
        public int id
        {
            get { return _id_vente_enchere; }
            set { _id_vente_enchere = value; }
        }

        private string _date_vente_enchere;
        public string date_vente_enchere
        {
            get { return _date_vente_enchere; }
            set { _date_vente_enchere = value; OnPropertyChanged("date_vente_enchere"); }
        }

        private int _id_lieu;
        public int id_lieu
        {
            get { return _id_lieu; }
            set { _id_lieu = value; OnPropertyChanged("id_lieu"); }
        }

        public EnchereViewModel(){}

        public EnchereViewModel(int id_vente_enchere_,string date_vente_enchere_,int id_lieu_)
        {
            this.id = id_vente_enchere_;
            this.date_vente_enchere = date_vente_enchere_;
            this.id_lieu = id_lieu_;
            
        }

         
        
        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string info)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(info));
                this.PropertyChanged(this, new PropertyChangedEventArgs(info));
                EnchereORM.updateEnchere(this);
            }
        }
    }
}