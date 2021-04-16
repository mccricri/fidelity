using System.IO;

namespace Fidelity.Services
{
    public interface IBarecodeDrawer
    {
        Stream DrawBarcode(ZXing.BarcodeFormat type, string value);
    }
}