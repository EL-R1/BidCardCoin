using System.ComponentModel;
using System.Runtime.CompilerServices;
using BidCardCoin.Annotations;
using BidCardCoin.ORM;

namespace BidCardCoin.Crtl
{
    public class PersonneViewModel : INotifyPropertyChanged
    {
        public PersonneViewModel() {}
        
        private int _id_personne;
        public int id
        {
            get { return _id_personne; }
            set { _id_personne = value; }
        }

        private string _nom;
        public string nom
        {
            get { return _nom; }
            set { _nom = value; OnPropertyChanged("nom"); }
        }

        private string _username;
        public string username
        {
            get { return _username; }
            set { _username = value; OnPropertyChanged("username"); }
        }

        private string _password;
        public string password
        {
            get { return _password; }
            set { _password = value; OnPropertyChanged("password"); }
        }

        private string _email;
        public string email
        {
            get { return _email; }
            set { _email = value; OnPropertyChanged("email"); }
        }

        private int _age;
        public int age
        {
            get { return _age; }
            set { _age = value; OnPropertyChanged("age"); }
        }



        public PersonneViewModel(int id_personne_,string nom_,string email_,int age_, string username_, string password_)
        {
            id = id_personne_;
            nom = nom_;
            email = email_;
            age = age_;
            username = username_;
            password = password_;
        }

        
        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string info)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(info));
                PropertyChanged(this, new PropertyChangedEventArgs(info));
                PersonneORM.updatePersonne(this);
            }
        }
    }
}