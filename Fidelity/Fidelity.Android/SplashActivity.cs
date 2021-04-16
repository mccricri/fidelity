
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;

namespace Fidelity.Droid
{

    [Activity(Theme = "@style/MyTheme.Splash", Icon = "@mipmap/ic_cards", MainLauncher = true, NoHistory = true, ScreenOrientation = ScreenOrientation.Portrait)]
    public class SplashScreen : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            StartActivity(typeof(MainActivity));
        }
    }
}