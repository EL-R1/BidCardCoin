using System.Collections.ObjectModel;
using BidCardCoin.Crtl;
using BidCardCoin.DAO;

namespace BidCardCoin.ORM
{
    public class PersonneORM
    {
        public static PersonneViewModel getPersonne(int idPersonne)
        {
            PersonneDAO pDAO=PersonneDAO.getPersonne(idPersonne);
            PersonneViewModel p = new PersonneViewModel(pDAO.id_personne, pDAO.nom, pDAO.email, pDAO.age);
            return p;
        }

        public static ObservableCollection<PersonneViewModel> listePersonnes()
        {
            ObservableCollection<PersonneDAO> lDAO = PersonneDAO.listePersonnes();
            ObservableCollection<PersonneViewModel> l = new ObservableCollection<PersonneViewModel>();
            foreach (PersonneDAO element in lDAO)
            {
                PersonneViewModel p = new PersonneViewModel(element.id_personne, element.nom, element.email, element.age);
                l.Add(p);
            }
            return l;
        }


        public static void updatePersonne(PersonneViewModel p)
        {
            PersonneDAO.updatePersonne(new PersonneDAO(p.id, p.nom, p.email, p.age));
        }

        public static void supprimerPersonne(int id)
        {
            PersonneDAO.supprimerPersonne(id);
        }

        public static int getLoginCount(string username, string password)
        {
            return PersonneDAO.getLoginCount(username, password);
        }

        public static void insertPersonne(PersonneViewModel p)
        {
            PersonneDAO.insertPersonne(new PersonneDAO(p.id, p.nom, p.email, p.age));
        }
    }
}