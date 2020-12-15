using System.Collections.ObjectModel;
using BidCardCoin.DAL;

namespace BidCardCoin.DAO
{
    public class PhotoDAO
    {
        public int id_photo;
        public int id_produit;

        public PhotoDAO(int id_photo_,int id_produit_)
        {
            this.id_photo = id_photo_;
            this.id_produit = id_produit_;
        }
        public static ObservableCollection<PhotoDAO>  listePhotos()
        {
            ObservableCollection<PhotoDAO> l = PhotoDAL.selectPhotos();
            return l;
        }

        public static PhotoDAO getPhoto(int idPhoto)
        {
            PhotoDAO p = PhotoDAL.getPhoto(idPhoto);
            return p;
        }

        public static void updatePhoto(PhotoDAO p)
        {
            PhotoDAL.updatePhoto(p);
        }

        public static void supprimerPhoto(int id)
        {
            PhotoDAL.supprimerPhoto(id);
        }

        public static void insertPhoto(PhotoDAO p)
        {
            PhotoDAL.insertPhoto(p);
        }
    }
}