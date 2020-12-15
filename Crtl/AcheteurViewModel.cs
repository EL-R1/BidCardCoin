using System.ComponentModel;
using System.Runtime.CompilerServices;
using BidCardCoin.Annotations;
using BidCardCoin.ORM;

namespace BidCardCoin.Crtl
{
    public class AcheteurViewModel : INotifyPropertyChanged
    {
        public AcheteurViewModel() {}
        
        private int _id_acheteur;
        public int id
        {
            get { return _id_acheteur; }
            set { _id_acheteur = value; }
        }

        private int _id_personne;
        public int id_personne
        {
            get { return _id_personne; }
            set { _id_personne = value; OnPropertyChanged("id_personne"); }
        }

        private byte _is_solvable;
        public byte is_solvable
        {
            get { return _is_solvable; }
            set { _is_solvable = value; OnPropertyChanged("is_solvable"); }
        }


        public AcheteurViewModel(int id_acheteur_,int id_personne_,byte is_solvable_)
        {
            this.id = id_acheteur_;
            this.id_personne = id_personne_;
            this.is_solvable = is_solvable_;
        }

        
        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string info)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(info));
                this.PropertyChanged(this, new PropertyChangedEventArgs(info));
                AcheteurORM.updateAcheteur(this);
            }
        }
    }
}