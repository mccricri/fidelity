using Fidelity.Views;
using Xamarin.Forms;

namespace Fidelity
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            
            DependencyService.Register<MainPage>();
            DependencyService.Register<ViewCartePage>();
            DependencyService.Register<ModCartePage>();

            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
