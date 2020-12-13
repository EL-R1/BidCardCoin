using System.ComponentModel;
using System.Runtime.CompilerServices;
using BidCardCoin.Annotations;

namespace BidCardCoin.Crtl
{
    public class CategorieViewModel : INotifyPropertyChanged
    {
        public CategorieViewModel() {}
        
        private int _id_categorie;
        public int id_categorie
        {
            get { return _id_categorie; }
            set { _id_categorie = value; }
        }

        private string _nom;
        public string nom
        {
            get { return _nom; }
            set { _nom = value; }
        }


        public CategorieViewModel(int id_categorie_,string nom_)
        {
            this.id_categorie = id_categorie_;
            this.nom = nom_;
        }

        
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}