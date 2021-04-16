using System;
using Fidelity.Models;
using Fidelity.Services;
using Fidelity.Views;
using Xamarin.Forms;

namespace Fidelity.ViewModels
{
    public class ViewCartePageViewModel : BindableBase
    {
        private Carte _modCarte;
        public Carte ModCarte
        {
            get => _modCarte;
            set { _modCarte = value; drawbc(); OnPropertyChanged("ModCarte"); }
        }

        private ImageSource _src;
        public ImageSource ImageBarcodeSource { get => _src; set { _src = value; OnPropertyChanged("ImageBarcodeSource"); } }

        private readonly IBarecodeDrawer _bcdrawer;

        internal void FindCarte(string value)
        {
            ModCarte = CardStore.FindCarte(value);
        }

        public Command ModifyCarteCommand { get; private set; }
        public Command DeleteCarteCommand { get; private set; }

        public ViewCartePageViewModel()
        {
            _bcdrawer = DependencyService.Get<IBarecodeDrawer>();
            ModifyCarteCommand = new Command(ModifiyCarte);
            DeleteCarteCommand = new Command(DeleteCarte);
        }

        private void drawbc()
        {
            try
            {
                var stream = _bcdrawer.DrawBarcode(_modCarte.Type, _modCarte.CB);
                ImageBarcodeSource = ImageSource.FromStream(() => { return stream; });
            }
            catch (Exception)
            {

            }
        }

        private async void ModifiyCarte()
        {
            await Shell.Current.GoToAsync("ModCartePage?id=" + ModCarte.Id);
        }

        private async void DeleteCarte()
        {
            var answer = await Shell.Current.DisplayAlert("Effacer la carte", "Tu crois vraiment que c'est une bonne idée ?", "Oui", "Non");
            if (answer == true)
            {
                CardStore.DeleteCarte(ModCarte);
                await Shell.Current.Navigation.PopAsync();
            }
        }
        
    }
}
