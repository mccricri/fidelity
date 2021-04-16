using System;
using System.Collections.Generic;
using Fidelity.Models;
using Fidelity.Services;
using Xamarin.Forms;

namespace Fidelity.ViewModels
{
    public class ModCartePageViewModel : BindableBase
    {
        private Carte _modCarte;
        public Carte ModCarte { 
            get => _modCarte; 
            set { SetProperty(ref _modCarte, value); } 
        }

        private ImageSource _source;
        public ImageSource ImageBarcodeSource { 
            get => _source; 
            set { SetProperty(ref _source , value);  } 
        }

        private string _titre;
        public string Titre
        {
            get => _titre; set
            {
                SetProperty(ref _titre, value);
            }
        }

        private int _selectType = 0;
        public int SelectedType
        {
            get => _selectType; set
            {
                if (_selectType != value)
                {
                    if( SetProperty(ref _selectType, value)){
                        _modCarte.Type = AllFormats[value];
                        OnPropertyChanged(nameof(ModCarte));
                    }
                }
            }
        }

        public List<ZXing.BarcodeFormat> AllFormats = new List<ZXing.BarcodeFormat> { ZXing.BarcodeFormat.EAN_13, ZXing.BarcodeFormat.QR_CODE, ZXing.BarcodeFormat.CODE_128, ZXing.BarcodeFormat.CODABAR, ZXing.BarcodeFormat.ITF, ZXing.BarcodeFormat.EAN_8, ZXing.BarcodeFormat.DATA_MATRIX, ZXing.BarcodeFormat.UPC_A, ZXing.BarcodeFormat.UPC_EAN_EXTENSION };

        private readonly IBarecodeDrawer _bcdrawer;
        public Command AddCarteCommand { get; private set; }

        public ModCartePageViewModel()
        {
            _bcdrawer = DependencyService.Get<IBarecodeDrawer>();
            AddCarteCommand = new Command(saveCarte);

            ModCarte = new Carte();
            Titre = "Ajout de carte";
            SelectedType = 0;
            ImageBarcodeSource = null;
        }

        private async void saveCarte()
        {
            CardStore.AddCarte(_modCarte);

            await Shell.Current.Navigation.PopAsync();
        }

        internal void FromId(string id)
        {
            var c = CardStore.FindCarte(id);
            if(c != null)
            {
                // clone local pour pas écraser l'existant de la liste
                ModCarte.Nom = c.Nom;
                ModCarte.Type = c.Type;
                ModCarte.CB = c.CB;
                ModCarte.Id = c.Id;

                Titre = "Modification de carte";
                SelectedType = AllFormats.IndexOf(ModCarte.Type);
                // On tente
                DrawBarcode();
            }
        }
    
        internal void NewScan(ZXing.BarcodeFormat barcodeFormat, string text)
        {
            ModCarte.CB = text;
            SelectedType = AllFormats.IndexOf(barcodeFormat);
            DrawBarcode();
        }

        public void DrawBarcode()
        {
            try
            {
                var stream = _bcdrawer.DrawBarcode(_modCarte.Type, ModCarte.CB);
                ImageBarcodeSource = ImageSource.FromStream(() => { return stream; });
            }
            catch (Exception)
            {
            }
        }

    }
}
