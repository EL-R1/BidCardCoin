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

        public PersonneDAO(int id_personne_,string nom_,string email_,int age_)
        {
            this.id_personne = id_personne_;
            this.nom = nom_;
            this.email = email_;
            this.age = age_;
        }
        public static ObservableCollection<PersonneDAO>  listePersonnes()
        {
            ObservableCollection<PersonneDAO> l = PersonneDAL.selectPersonnes();
            return l;
        }

        public static PersonneDAO getPersonne(int idPersonne)
        {
            PersonneDAO p = PersonneDAL.getPersonne(idPersonne);
            return p;
        }

        public static void updatePersonne(PersonneDAO p)
        {
            PersonneDAL.updatePersonne(p);
        }

        public static void supprimerPersonne(int id)
        {
            PersonneDAL.supprimerPersonne(id);
        }

        public static void insertPersonne(PersonneDAO p)
        {
            PersonneDAL.insertPersonne(p);
        }
    }
}