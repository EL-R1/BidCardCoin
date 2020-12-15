using System.ComponentModel;
using System.Runtime.CompilerServices;
using BidCardCoin.Annotations;
using BidCardCoin.ORM;

namespace BidCardCoin.Crtl
{
    public class CategorieViewModel : INotifyPropertyChanged
    {
        public CategorieViewModel() {}
        
        private int _id_categorie;
        public int id
        {
            get { return _id_categorie; }
            set { _id_categorie = value; }
        }

        private string _nom;
        public string nom
        {
            get { return _nom; }
            set { _nom = value; OnPropertyChanged("nom"); }
        }


        public CategorieViewModel(int id_categorie_,string nom_)
        {
            this.id = id_categorie_;
            this.nom = nom_;
        }

        
        public event PropertyChangedEventHandler PropertyChanged;



        private void OnPropertyChanged(string info)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(info));
                this.PropertyChanged(this, new PropertyChangedEventArgs(info));
                CategorieORM.updateCategorie(this);
            }
        }
    }
}