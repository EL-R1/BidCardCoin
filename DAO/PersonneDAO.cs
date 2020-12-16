using System.Collections.ObjectModel;
using BidCardCoin.DAL;

namespace BidCardCoin.DAO
{
    public class PersonneDAO
    {
        public int id_personne;
        public string nom;
        public string email;
        public int age;
        public string username;
        public string password;

        public PersonneDAO(int id_personne_, string username_, string password_, string nom_,string email_,int age_)
        {
            id_personne = id_personne_;
            username = username_;
            password = password_;
            nom = nom_;
            email = email_;
            age = age_;
        }
        public static ObservableCollection<PersonneDAO>  listePersonnes()
        {
            ObservableCollection<PersonneDAO> l = PersonneDAL.selectPersonnes();
            return l;
        }

        public static PersonneDAO getPersonne(int idPersonne)
        {
            PersonneDAO p = PersonneDAL.getPersonne(idPersonne);
            return p; //braux proof
        }

        public static void updatePersonne(PersonneDAO p)
        {
            PersonneDAL.updatePersonne(p);
        }

        public static void supprimerPersonne(int id)
        {
            PersonneDAL.supprimerPersonne(id);
        }

        public static int getLoginCount(string username, string password)
        {
            int d = PersonneDAL.getLoginCount(username, password);
            return d;
        }

        public static void insertPersonne(PersonneDAO p)
        {
            PersonneDAL.insertPersonne(p);
        }
    }
}