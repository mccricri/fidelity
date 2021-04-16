using Fidelity.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Fidelity.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
        private MainPageViewModel _vm;
        public MainPage()
        {
            InitializeComponent();
            BindingContext = _vm = new MainPageViewModel();
        }

        private void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {           
            _vm.ViewCarteCommand.Execute(e.Item);
        }
    }
}
