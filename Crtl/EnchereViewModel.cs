using System.ComponentModel;
using System.Runtime.CompilerServices;
using BidCardCoin.Annotations;

namespace BidCardCoin.Crtl
{
    public class EnchereViewModel : INotifyPropertyChanged
    {
        private int _id_vente_enchere;
        public int id_vente_enchere
        {
            get { return _id_vente_enchere; }
            set { _id_vente_enchere = value; }
        }

        private string _date_vente_enchere;
        public string date_vente_enchere
        {
            get { return _date_vente_enchere; }
            set { _date_vente_enchere = value; }
        }

        private int _id_lieu;
        public int id_lieu
        {
            get { return _id_lieu; }
            set { _id_lieu = value; }
        }

        public EnchereViewModel(){}

        public EnchereViewModel(int id_vente_enchere_,string date_vente_enchere_,int id_lieu_)
        {
            this.id_vente_enchere = id_vente_enchere_;
            this.date_vente_enchere = date_vente_enchere_;
            this.id_lieu = id_lieu_;
        }

        
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}