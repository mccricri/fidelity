using System;
using System.IO;
using Android.Graphics;
using Fidelity.Droid;
using Fidelity.Services;
using Xamarin.Forms;

[assembly: Dependency(typeof(BarcodeDrawer))]
namespace Fidelity.Droid
{
    class BarcodeDrawer : IBarecodeDrawer
    {
        private static int WIDTH = 1800;
        private static int HEIGHT = 900;

        public Stream DrawBarcode(ZXing.BarcodeFormat type, string value)
        {
            var barcodeWriter = new ZXing.Mobile.BarcodeWriter
            {
                Format = type,

                Options = new ZXing.Common.EncodingOptions
                {
                    Width = WIDTH,
                    Height = HEIGHT,
                    Margin = 5
                }
            };

            barcodeWriter.Renderer = new ZXing.Mobile.BitmapRenderer();
            Bitmap bitmap;
            try
            {
                bitmap = barcodeWriter.Write(value);
            }
            catch (Exception)
            {
                // empty image
                bitmap = Bitmap.CreateBitmap(WIDTH, HEIGHT, Bitmap.Config.Argb8888);

                // on écrit un message d'erreur
                var can = new Canvas(bitmap);
                Paint pMemberNamePaint = new Paint(PaintFlags.LinearText);
                pMemberNamePaint.SetStyle(Paint.Style.Fill);
                pMemberNamePaint.Color = Android.Graphics.Color.Black;
                pMemberNamePaint.TextSize = 180 * 1;

                can.DrawText("Wrong format", 100, HEIGHT / 2, pMemberNamePaint);

            }

            var stream = new MemoryStream();
            bitmap.Compress(Bitmap.CompressFormat.Png, 100, stream);  // this is the diff between iOS and Android
            stream.Position = 0;
            return stream;
        }
    }
}