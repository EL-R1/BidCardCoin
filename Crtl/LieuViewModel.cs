using System.ComponentModel;
using System.Runtime.CompilerServices;
using BidCardCoin.Annotations;
using BidCardCoin.ORM;

namespace BidCardCoin.Crtl
{
    public class LieuViewModel : INotifyPropertyChanged
    {
        public LieuViewModel() {}
        
        private int _id_lieu;
        public int id
        {
            get { return _id_lieu; }
            set { _id_lieu = value; OnPropertyChanged("id_lieu"); }
        }

        private string _nom;
        public string nom
        {
            get { return _nom; }
            set { _nom = value; OnPropertyChanged("nom"); }
        }

        private string _adresse;
        public string adresse
        {
            get { return _adresse; }
            set { _adresse = value; OnPropertyChanged("adresse"); }
        }

        private string _ville;
        public string ville
        {
            get { return _ville; }
            set { _ville = value; OnPropertyChanged("ville"); }
        }

        private int _code_postal;
        public int code_postal
        {
            get { return _code_postal; }
            set { _code_postal = value; OnPropertyChanged("code_postal"); }
        }


        public LieuViewModel(int id_lieu_,string nom_,string adresse_,string ville_,int code_postal_)
        {
            this.id = id_lieu_;
            this.nom = nom_;
            this.adresse = adresse_;
            this.ville = ville_;
            this.code_postal = code_postal_;
        }

        
        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string info)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(info));
                this.PropertyChanged(this, new PropertyChangedEventArgs(info));
                LieuORM.updateLieu(this);
            }
        }
    }
}