using System;

namespace Fidelity.Models
{
    public class Carte : BindableBase
    {
        public Carte()
        {
            Id = Guid.NewGuid().ToString();
            Nom = "";
            CB = "";
            Type = ZXing.BarcodeFormat.EAN_13;
        }

        public Carte(string nom, string cb, ZXing.BarcodeFormat type) : this()
        {
            this.Nom = nom;
            this.CB = cb;
            this.Type = type;
        }

        private string _id;
        public string Id
        {
            get { return _id; }
            set { SetProperty(ref _id, value);}
        }
        private string _nom;
        public string Nom
        {
            get
            { return _nom; }
            set { SetProperty(ref _nom, value); }
        }

        private string _cb;
        public string CB
        {
            get { return _cb; }
            set { SetProperty(ref _cb,value);}
        }

        private ZXing.BarcodeFormat _type;
        public ZXing.BarcodeFormat Type
        {
            get { return _type; }
            set { SetProperty(ref _type, value);}
        }
    }
}
