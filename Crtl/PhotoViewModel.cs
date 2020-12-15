using System.ComponentModel;
using System.Runtime.CompilerServices;
using BidCardCoin.Annotations;
using BidCardCoin.ORM;

namespace BidCardCoin.Crtl
{
    public class PhotoViewModel : INotifyPropertyChanged
    {
        public PhotoViewModel() {}
        
        private int _id_photo;
        public int id
        {
            get { return _id_photo; }
            set { _id_photo = value; }
        }

        private int _id_produit;
        public int id_produit
        {
            get { return _id_produit; }
            set { _id_produit = value; OnPropertyChanged("id_produit"); }
        }


        public PhotoViewModel(int id_photo_,int id_produit_)
        {
            this.id = id_photo_;
            this.id_produit = id_produit_;
        }

        
        public event PropertyChangedEventHandler PropertyChanged;



        private void OnPropertyChanged(string info)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(info));
                this.PropertyChanged(this, new PropertyChangedEventArgs(info));
                PhotoORM.updatePhoto(this);
            }
        }
    }
}