using Fidelity.Views;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Fidelity
{
    public partial class App : Application
    {
        const int smallWightResolution = 768;
        const int smallHeightResolution = 1280;

        const int bigWightResolution = 1080;
        const int bigHeightResolution = 2400;

        public App()
        {
            InitializeComponent();
            
            DependencyService.Register<MainPage>();
            DependencyService.Register<ViewCartePage>();
            DependencyService.Register<ModCartePage>();

            LoadStyles();

            MainPage = new AppShell();
        }

        private void LoadStyles()
        {
            if (IsASmallDevice())
            {
                AppDictionnary.MergedDictionaries.Add(SmallStyle.SharedInstance);
            }
            else if (IsABigDevice())
            {
                AppDictionnary.MergedDictionaries.Add(BigStyle.SharedInstance);
            }
            else
            {
                AppDictionnary.MergedDictionaries.Add(GeneralStyle.SharedInstance);
            }
        }

        private bool IsABigDevice()
        {
            // Get Metrics
            var mainDisplayInfo = DeviceDisplay.MainDisplayInfo;

            // Width (in pixels)
            var width = mainDisplayInfo.Width;

            // Height (in pixels)
            var height = mainDisplayInfo.Height;
            return (width >= bigWightResolution && height >= bigHeightResolution);
        }

        public static bool IsASmallDevice()
        {
            // Get Metrics
            var mainDisplayInfo = DeviceDisplay.MainDisplayInfo;

            // Width (in pixels)
            var width = mainDisplayInfo.Width;

            // Height (in pixels)
            var height = mainDisplayInfo.Height;
            return (width <= smallWightResolution && height <= smallHeightResolution);
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
