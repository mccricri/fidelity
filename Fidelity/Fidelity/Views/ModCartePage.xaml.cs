using System;
using Fidelity.Services;
using Fidelity.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ZXing.Mobile;
using ZXing.Net.Mobile.Forms;

namespace Fidelity.Views
{

    [XamlCompilation(XamlCompilationOptions.Compile)]
    [QueryProperty("CarteId", "id")]
    public partial class ModCartePage : ContentPage
    {
        private ModCartePageViewModel _vm;

        public ModCartePage()
        {
            InitializeComponent();
            BindingContext = _vm = new ModCartePageViewModel();
        }

        // Appeler que sur le bouton "physique" android
        // !! Mais pas sur le bouton retour de la toolbar....
        protected override bool OnBackButtonPressed()
        {
            Device.BeginInvokeOnMainThread(async () => {
                if (await DisplayAlert("Confirm", "On oublie les modifications ?", "Oui", "Oups")) 
                    await Navigation.PopAsync(); 
            });

            return true;
        }

        private void Button_Clicked(object sender, System.EventArgs e)
        {
            _vm.DrawBarcode();
        }

        public string CarteId
        {
            set
            {
                _vm.FromId(value);
            }
        }

        private async void Button_Clicked_1(object sender, EventArgs e)
        {
            var sc = DependencyService.Get<IScanner>();
            var (type,text) = await sc.ScanAsync(_vm.AllFormats);
            
            if (type!= null && !string.IsNullOrEmpty(text))
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    _vm.NewScan((ZXing.BarcodeFormat)type, text);
                });
            }
        }
    }
}
