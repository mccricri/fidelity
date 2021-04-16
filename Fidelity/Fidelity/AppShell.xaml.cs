
using Fidelity.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Fidelity
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(MainPage), typeof(MainPage));
            Routing.RegisterRoute(nameof(ViewCartePage), typeof(ViewCartePage));
            Routing.RegisterRoute(nameof(ModCartePage), typeof(ModCartePage));
        }

    }
}