using System.ComponentModel;
using System.Runtime.CompilerServices;
using BidCardCoin.Annotations;

namespace BidCardCoin.Crtl
{
    public class PersonneViewModel : INotifyPropertyChanged
    {
        public PersonneViewModel() {}
        
        private int _id_personne;
        public int id_personne
        {
            get { return _id_personne; }
            set { _id_personne = value; }
        }

        private string _nom;
        public string nom
        {
            get { return _nom; }
            set { _nom = value; }
        }

        private string _email;
        public string email
        {
            get { return _email; }
            set { _email = value; }
        }

        private int _age;
        public int age
        {
            get { return _age; }
            set { _age = value; }
        }


        public PersonneViewModel(int id_personne_,string nom_,string email_,int age_)
        {
            this.id_personne = id_personne_;
            this.nom = nom_;
            this.email = email_;
            this.age = age_;
        }

        
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}