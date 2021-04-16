using Fidelity.Models;
using Fidelity.Services;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace Fidelity.ViewModels
{
    public class MainPageViewModel : BindableBase
    {
        public Command AddCarteCommand { get; private set; }
        public Command ViewCarteCommand { get; private set; }
        public ObservableCollection<Carte> CardList { get; private set; }

        public Carte SelectedCarte { get; set; }

        public MainPageViewModel()
        {
            AddCarteCommand = new Command(addCarte);

            ViewCarteCommand = new Command(modCarte);

            CardList = CardStore.GetAllCartes();
        }

        private async void addCarte()
        {
            await Shell.Current.GoToAsync("ModCartePage" );
        }

        private async void modCarte()
        {
            await Shell.Current.GoToAsync("ViewCartePage?id=" + SelectedCarte.Id);
        }
    }
}
