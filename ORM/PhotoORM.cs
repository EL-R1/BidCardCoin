using System.Collections.ObjectModel;
using BidCardCoin.Crtl;
using BidCardCoin.DAO;

namespace BidCardCoin.ORM
{
    public class PhotoORM
    {
        public static PhotoViewModel getPhoto(int idPhoto)
        {
            PhotoDAO pDAO=PhotoDAO.getPhoto(idPhoto);
            PhotoViewModel p = new PhotoViewModel(pDAO.id_photo, pDAO.id_produit);
            return p;
        }

        public static ObservableCollection<PhotoViewModel> listePhotos()
        {
            ObservableCollection<PhotoDAO> lDAO = PhotoDAO.listePhotos();
            ObservableCollection<PhotoViewModel> l = new ObservableCollection<PhotoViewModel>();
            foreach (PhotoDAO element in lDAO)
            {
                PhotoViewModel p = new PhotoViewModel(element.id_photo, element.id_produit);
                l.Add(p);
            }
            return l;
        }


        public static void updatePhoto(PhotoViewModel p)
        {
            PhotoDAO.updatePhoto(new PhotoDAO(p.id, p.id_produit));
        }

        public static void supprimerPhoto(int id)
        {
            PhotoDAO.supprimerPhoto(id);
        }

        public static void insertPhoto(PhotoViewModel p)
        {
            PhotoDAO.insertPhoto(new PhotoDAO(p.id, p.id_produit));
        }
    }
}