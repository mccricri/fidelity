using Fidelity.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Fidelity.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    [QueryProperty("CarteId", "id")]
    public partial class ViewCartePage : ContentPage
    {
        private ViewCartePageViewModel _vm;

        public ViewCartePage()
        {
            InitializeComponent();
            BindingContext = _vm = new ViewCartePageViewModel();
        }

        public string CarteId
        {
            set
            {
                _vm.FindCarte(value);
            }
        }

    }
}