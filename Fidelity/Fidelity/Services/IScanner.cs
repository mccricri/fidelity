using System.Collections.Generic;
using System.Threading.Tasks;
using ZXing;

namespace Fidelity.Services
{
    public interface IScanner
    {
        Task<(BarcodeFormat?, string)> ScanAsync(List<BarcodeFormat> acceptedFormat);
    }
}
