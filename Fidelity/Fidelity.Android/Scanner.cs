using Fidelity.Droid;
using Fidelity.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;
using ZXing;
using ZXing.Mobile;
using Android.Content;
using Android.App;
using Xamarin.Essentials;

[assembly: Dependency(typeof(Scanner))]
namespace Fidelity.Droid
{
    class Scanner : IScanner 
    {
        public async Task<(BarcodeFormat?, string)> ScanAsync(List<BarcodeFormat> acceptedFormat)
        {
            // Ask permission if needed
            if (ZXing.Net.Mobile.Android.PermissionsHandler.NeedsPermissionRequest(Platform.AppContext))
            {
                var ac = Platform.CurrentActivity;
                var good = await ZXing.Net.Mobile.Android.PermissionsHandler.RequestPermissionsAsync(ac);

                if (!good) return (null, null);
            }

            var optionsCustom = new MobileBarcodeScanningOptions
            {
                AutoRotate = true,
                UseNativeScanning = true,
                TryHarder = true
            };

            optionsCustom.PossibleFormats.AddRange(acceptedFormat);

            var scanner = new MobileBarcodeScanner()
            {
                TopText = "Scan la carte",
            };
            scanner.AutoFocus();
            try
            {
                var scanResult = await scanner.Scan(optionsCustom);
                if (scanResult == null) return (null,null);

                return (scanResult.BarcodeFormat,scanResult.Text);
            }
            catch (Exception)
            {
                scanner.Cancel();

                return (null, null);
            }

        }
    }
}