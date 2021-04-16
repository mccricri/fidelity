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

        protected override bool OnBackButtonPressed()
        {
            Device.BeginInvokeOnMainThread(async () => {
                var result = await DisplayAlert("Alert!", "On enregistre pas ?", "Si", "Non");
                if (!result) await Navigation.PopAsync(); // or anything else
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
                    Navigation.PopAsync();

                    _vm.NewScan((ZXing.BarcodeFormat)type, text);
                });
            }
        }
    }
}
