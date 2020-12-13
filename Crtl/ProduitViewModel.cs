using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using BidCardCoin.Annotations;

namespace BidCardCoin.Crtl
{
    public class ProduitViewModel : INotifyPropertyChanged
    {
        public ProduitViewModel() {}
        
        private int _id_produit;

        public int id_produit
        {
            get { return _id_produit; }
            set { _id_produit = value; }
        }

        private int _id_lot;

        public int id_lot
        {
            get { return _id_lot; }
            set { _id_lot = value; }
        }

        private float _prix_depart;

        public float prix_depart
        {
            get { return _prix_depart; }
            set { _prix_depart = value; }
        }

        private string _description;

        public string description
        {
            get { return _description; }
            set { _description = value; }
        }

        private string _date_vente;

        public string date_vente
        {
            get { return _date_vente; }
            set { _date_vente = value; }
        }

        private float _estimation;

        public float estimation
        {
            get { return _estimation; }
            set { _estimation = value; }
        }

        private byte _is_vendu;

        public byte is_vendu
        {
            get { return _is_vendu; }
            set { _is_vendu = value; }
        }

        private float _prix_reserve;

        public float prix_reserve
        {
            get { return _prix_reserve; }
            set { _prix_reserve = value; }
        }

        private string _region;

        public string region
        {
            get { return _region; }
            set { _region = value; }
        }

        private string _attribut;

        public string attribut
        {
            get { return _attribut; }
            set { _attribut = value; }
        }


        public ProduitViewModel(int id_produit_, int id_lot_, float prix_depart_, string description_,
            string date_vente_,
            float estimation_, byte is_vendu_, float prix_reserve_, string region_, string attribut_)
        {
            this.id_produit = id_produit_;
            this.id_lot = id_lot_;
            this.prix_depart = prix_depart_;
            this.description = description_;
            this.date_vente = date_vente_;
            this.estimation = estimation_;
            this.is_vendu = is_vendu_;
            this.prix_reserve = prix_reserve_;
            this.region = region_;
            this.attribut = attribut_;
        }
        
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}