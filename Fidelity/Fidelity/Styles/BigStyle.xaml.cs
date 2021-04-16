using Xamarin.Forms;

namespace Fidelity
{
    public partial class BigStyle : ResourceDictionary
	{
		public static BigStyle SharedInstance { get; } = new BigStyle();
		public BigStyle ()
		{
			InitializeComponent ();
		}
	}
}